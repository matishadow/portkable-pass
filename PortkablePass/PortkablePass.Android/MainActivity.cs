using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Text;
using PortkablePass.Cryptography;
using PortkablePass.Cryptography.CharacterSpaceGenerators;
using PortkablePass.Encoding;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Android
{
    [Activity(Label = "PortkablePass.Android", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
        private readonly IPasswordGenerator passwordGenerator;

        public MainActivity()
        {
            IPasswordTruncator passwordTruncator = new PasswordTruncator();
            IUtf8Converter utf8Converter = new Utf8Converter();
            IHmacGenerator sha1HmacGenerator = new HmacSha1Generator(utf8Converter);
            IHmacGenerator sha256HmacGenerator = new HmacSha256Generator(utf8Converter);
            IHmacGenerator sha512HmacGenerator = new HmacSha512Generator(utf8Converter);
            IHmacGeneratorResolver hmacGeneratorResolver =
                new HmacGeneratorResolver(new List<IHmacGenerator>
                {
                    sha1HmacGenerator,
                    sha256HmacGenerator,
                    sha512HmacGenerator
                });
            ICharacterSpaceGenerator characterSpaceGenerator = new CharacterSpaceGenerator(new List<ISingularCharacterSpaceGenerator>
            {
                new UppercaseCharacterSpaceGenerator(),
                new LowercaseCharacterSpaceGenerator(),
                new DigitCharacterSpaceGenerator(),
                new SpecialCharacterSpaceGenerator()
            });
            IHmacToArbitraryEncodingConverter hmacToArbitraryEncodingConverter = new HmacToArbitraryEncodingConverter();

            passwordGenerator = new PasswordGenerator(passwordTruncator, hmacGeneratorResolver, characterSpaceGenerator,
                utf8Converter, hmacToArbitraryEncodingConverter);
        }

        protected MainActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            FindViewById<EditText>(Resource.Id.domainEditText).TextChanged += delegate { UpdateGeneratedPassword(); };
            FindViewById<EditText>(Resource.Id.masterEditText).TextChanged += delegate { UpdateGeneratedPassword(); };
            FindViewById<SeekBar>(Resource.Id.lengthSeekBar).ProgressChanged += delegate { UpdateGeneratedPassword(); };
            FindViewById<CheckBox>(Resource.Id.uppercaseCheckBox).CheckedChange += delegate { UpdateGeneratedPassword(); };
            FindViewById<CheckBox>(Resource.Id.lowercaseCheckBox).CheckedChange += delegate { UpdateGeneratedPassword(); };
            FindViewById<CheckBox>(Resource.Id.digitsCheckBox).CheckedChange += delegate { UpdateGeneratedPassword(); };
            FindViewById<CheckBox>(Resource.Id.specialCheckBox).CheckedChange += delegate { UpdateGeneratedPassword(); };
            FindViewById<RadioGroup>(Resource.Id.hashRadioGroup).CheckedChange += delegate { UpdateGeneratedPassword(); };
        }

        private void UpdateGeneratedPassword()
        {
            string domainName = FindViewById<EditText>(Resource.Id.domainEditText)?.Text;
            string masterPassword = FindViewById<EditText>(Resource.Id.masterEditText)?.Text;
            string hmacGeneratorFunction =
                FindViewById<RadioButton>(FindViewById<RadioGroup>(Resource.Id.hashRadioGroup).CheckedRadioButtonId)
                    .Text.ToLower().Replace("-", string.Empty);
            Enum.TryParse(hmacGeneratorFunction.First().ToString().ToUpper() + hmacGeneratorFunction.Substring(1),
                out HmacGenerator hashFunction);
            int length = FindViewById<SeekBar>(Resource.Id.lengthSeekBar).Progress;
            CharacterSpace characterSpace =
                (FindViewById<CheckBox>(Resource.Id.uppercaseCheckBox).Checked
                    ? CharacterSpace.Uppercase
                    : CharacterSpace.None) |
                (FindViewById<CheckBox>(Resource.Id.lowercaseCheckBox).Checked
                    ? CharacterSpace.Lowercase
                    : CharacterSpace.None) |
                (FindViewById<CheckBox>(Resource.Id.digitsCheckBox).Checked
                    ? CharacterSpace.Digits
                    : CharacterSpace.None) |
                (FindViewById<CheckBox>(Resource.Id.specialCheckBox).Checked
                    ? CharacterSpace.Special
                    : CharacterSpace.None);

            var generatedPassword = FindViewById<EditText>(Resource.Id.generatedEditText);
            try
            {
                generatedPassword.Text =
                    passwordGenerator.GeneratePassword(domainName, masterPassword, length, hashFunction, characterSpace);
            }
            catch (Exception e)
            {
                Toast.MakeText(ApplicationContext, e.Message, ToastLength.Short);
            }
        }
    }
}


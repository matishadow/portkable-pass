using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Text;
using PortkablePass.Cryptography;
using PortkablePass.Encoding;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Android
{
    [Activity(Label = "PortkablePass.Android", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Theme.Custom")]
    public class MainActivity : Activity
    {
        private readonly IPasswordGenerator passwordGenerator;

        public MainActivity(IPasswordGenerator passwordGenerator)
        {
            this.passwordGenerator = passwordGenerator;
        }

        protected MainActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MainActivity()
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
            Enum.TryParse(
                FindViewById<RadioButton>(FindViewById<RadioGroup>(Resource.Id.hashRadioGroup).CheckedRadioButtonId)
                    .Text.ToLower().Replace("-", string.Empty), out HmacGenerator hashFunction);
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
            generatedPassword.Text =
                passwordGenerator.GeneratePassword(domainName, masterPassword, length, hashFunction, characterSpace);
        }
    }
}


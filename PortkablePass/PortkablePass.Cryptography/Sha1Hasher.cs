using System.Security.Cryptography;
using System.Text;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Cryptography
{
    public class Sha1Hasher : ISha1Hasher
    {
        private const string HexadecimalFormater = "X2";
        private readonly IUtf8Converter utf8Converter;

        public Sha1Hasher(IUtf8Converter utf8Converter)
        {
            this.utf8Converter = utf8Converter;
        }

        public string ComputeStringHash(string input)
        {
            if (input == null) return null;

            using (var sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(utf8Converter.ConvertToBytes(input));
                var stringBuilder = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                    stringBuilder.Append(b.ToString(HexadecimalFormater));

                return stringBuilder.ToString();
            }
        }
    }
}
using System;
using System.Linq;
using System.Security.Cryptography;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Cryptography
{
    public class HmacSha1Generator : IHmacSha1Generator
    {
        private readonly IUtf8Converter utf8Converter;

        public HmacSha1Generator(IUtf8Converter utf8Converter)
        {
            this.utf8Converter = utf8Converter;
        }

        public byte[] GenerateHmacSha1Hash(byte[] input, byte[] key)
        {
            CheckArguments(input, key);
            var hmacsha1 = new HMACSHA1(key);

            return hmacsha1.ComputeHash(input);
        }

        public byte[] GenerateHmacSha1Hash(string input, byte[] key)
        {
            CheckArguments(input, key);

            byte[] inputBytes = utf8Converter.ConvertToBytes(input);

            var hmacsha1 = new HMACSHA1(key);

            return hmacsha1.ComputeHash(inputBytes);
        }

        private void CheckArguments(object input, byte[] key)
        {
            if (input == null || key == null)
                throw new ArgumentNullException();
            if (!key.Any())
                throw new ArgumentException();
        }
    }
}
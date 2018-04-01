using System;
using System.Linq;
using System.Security.Cryptography;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Cryptography
{
    public class HmacSha1Generator : IHmacSha1Generator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private readonly IUtf8Converter utf8Converter;

        public HmacGenerator HmacGenerator => HmacGenerator.Sha1;

        public HmacSha1Generator(IUtf8Converter utf8Converter)
        {
            this.utf8Converter = utf8Converter;
        }

        public byte[] GenerateHmacHash(byte[] input, byte[] key)
        {
            var hmacsha1 = new HMACSHA1(key);

            return hmacsha1.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, byte[] key)
        {
            byte[] inputBytes = utf8Converter.ConvertToBytes(input);

            var hmacsha1 = new HMACSHA1(key);

            return hmacsha1.ComputeHash(inputBytes);
        }

        public byte[] GenerateHmacHash(byte[] input, string key)
        {
            var hmacsha1 = new HMACSHA1(utf8Converter.ConvertToBytes(key));

            return hmacsha1.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, string key)
        {
            var hmacsha1 = new HMACSHA1(utf8Converter.ConvertToBytes(key));

            return hmacsha1.ComputeHash(utf8Converter.ConvertToBytes(input));
        }
    }
}
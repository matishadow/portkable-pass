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
    public class HmacSha256Generator : IHmacSha256Generator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private readonly IUtf8Converter utf8Converter;

        public HmacGenerator HmacGenerator => HmacGenerator.Sha256;

        public HmacSha256Generator(IUtf8Converter utf8Converter)
        {
            this.utf8Converter = utf8Converter;
        }

        public byte[] GenerateHmacHash(byte[] input, byte[] key)
        {
            var hmacsha256 = new HMACSHA256(key);

            return hmacsha256.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, byte[] key)
        {
            byte[] inputBytes = utf8Converter.ConvertToBytes(input);

            var hmacsha256 = new HMACSHA256(key);

            return hmacsha256.ComputeHash(inputBytes);
        }

        public byte[] GenerateHmacHash(byte[] input, string key)
        {
            var hmacsha256 = new HMACSHA256(utf8Converter.ConvertToBytes(key));

            return hmacsha256.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, string key)
        {
            var hmacsha256 = new HMACSHA256(utf8Converter.ConvertToBytes(key));

            return hmacsha256.ComputeHash(utf8Converter.ConvertToBytes(input));
        }
    }
}
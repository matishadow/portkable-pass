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
    public class HmacSha512Generator : IHmacSha512Generator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private readonly IUtf8Converter utf8Converter;

        public HmacGenerator HmacGenerator => HmacGenerator.Sha512;

        public HmacSha512Generator(IUtf8Converter utf8Converter)
        {
            this.utf8Converter = utf8Converter;
        }

        public byte[] GenerateHmacHash(byte[] input, byte[] key)
        {
            var hmacsha512 = new HMACSHA512(key);

            return hmacsha512.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, byte[] key)
        {
            byte[] inputBytes = utf8Converter.ConvertToBytes(input);

            var hmacsha512 = new HMACSHA512(key);

            return hmacsha512.ComputeHash(inputBytes);
        }

        public byte[] GenerateHmacHash(byte[] input, string key)
        {
            var hmacsha512 = new HMACSHA512(utf8Converter.ConvertToBytes(key));

            return hmacsha512.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, string key)
        {
            var hmacsha512 = new HMACSHA512(utf8Converter.ConvertToBytes(key));

            return hmacsha512.ComputeHash(utf8Converter.ConvertToBytes(input));
        }
    }
}
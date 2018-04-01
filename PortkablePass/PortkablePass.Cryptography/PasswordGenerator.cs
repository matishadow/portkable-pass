using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Cryptography
{
    public class PasswordGenerator : IPasswordGenerator, 
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private readonly IPasswordTruncator passwordTruncator;
        private readonly IHmacGeneratorResolver hmacGeneratorResolver;
        private readonly ICharacterSpaceGenerator characterSpaceGenerator;
        private readonly IUtf8Converter utf8Converter;
        private readonly IHmacToArbitraryEncodingConverter hmacToArbitraryEncodingConverter;

        public PasswordGenerator(IPasswordTruncator passwordTruncator, IHmacGeneratorResolver hmacGeneratorResolver, ICharacterSpaceGenerator characterSpaceGenerator, IUtf8Converter utf8Converter, IHmacToArbitraryEncodingConverter hmacToArbitraryEncodingConverter)
        {
            this.passwordTruncator = passwordTruncator;
            this.hmacGeneratorResolver = hmacGeneratorResolver;
            this.characterSpaceGenerator = characterSpaceGenerator;
            this.utf8Converter = utf8Converter;
            this.hmacToArbitraryEncodingConverter = hmacToArbitraryEncodingConverter;
        }

        public string GeneratePassword(string domainName, string masterPassword, int length,
            HmacGenerator hmacGenerator, CharacterSpace characterSpace)
        {
            IHmacGenerator generator = hmacGeneratorResolver.ResolverHmacGenerator(hmacGenerator);
            string space = characterSpaceGenerator.GenerateCharacterSpace(characterSpace);

            byte[] hmac = generator.GenerateHmacHash(domainName, masterPassword);
            string password = hmacToArbitraryEncodingConverter.ConvertToArbitraryEncodedString(hmac, space);
            string truncatedPassword = passwordTruncator.Truncate(password, length);

            return truncatedPassword;
        }
    }
}
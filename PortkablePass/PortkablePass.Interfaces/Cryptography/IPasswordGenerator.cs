using PortkablePass.Enums;

namespace PortkablePass.Interfaces.Cryptography
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(string domainName, string masterPassword, int length,
            HmacGenerator hmacGenerator, CharacterSpace characterSpace);
    }
}
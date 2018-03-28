using PortkablePass.Enums;

namespace PortkablePass.Interfaces.Cryptography
{
    public interface ICharacterSpaceGenerator
    {
        string GenerateCharacterSpace(CharacterSpace characterSpace);
    }
}
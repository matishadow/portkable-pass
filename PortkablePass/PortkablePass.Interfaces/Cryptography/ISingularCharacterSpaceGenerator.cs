using PortkablePass.Enums;

namespace PortkablePass.Interfaces.Cryptography
{
    public interface ISingularCharacterSpaceGenerator
    {
        CharacterSpace SpaceIdentifier { get; }
        string GenerateSingularCharacterSpace();
    }
}
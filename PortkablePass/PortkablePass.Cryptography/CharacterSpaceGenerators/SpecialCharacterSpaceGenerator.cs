using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class SpecialCharacterSpaceGenerator : ISingularCharacterSpaceGenerator
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Special;

        public string GenerateSingularCharacterSpace()
        {
            return "`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./";
        }
    }
}
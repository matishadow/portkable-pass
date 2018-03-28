using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class LowercaseCharacterSpaceGenerator : ISingularCharacterSpaceGenerator
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Lowercase;

        public string GenerateSingularCharacterSpace()
        {
            return @"abcdefghijklmnopqrstuvwxyz";
        }
    }
}
using System.Linq;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class DigitCharacterSpaceGenerator : ISingularCharacterSpaceGenerator
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Digits;

        public string GenerateSingularCharacterSpace()
        {
            return string.Join(string.Empty, Enumerable.Range(0, 10).ToArray());
        }
    }
}
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class UppercaseCharacterSpaceGenerator : LowercaseCharacterSpaceGenerator, ISingularCharacterSpaceGenerator
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Uppercase;

        public new string GenerateSingularCharacterSpace()
        {
            return base.GenerateSingularCharacterSpace().ToUpper();
        }
    }
}
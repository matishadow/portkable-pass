using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class UppercaseCharacterSpaceGenerator : LowercaseCharacterSpaceGenerator, ISingularCharacterSpaceGenerator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Uppercase;

        public new string GenerateSingularCharacterSpace()
        {
            return base.GenerateSingularCharacterSpace().ToUpper();
        }
    }
}
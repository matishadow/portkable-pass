using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class SpecialCharacterSpaceGenerator : ISingularCharacterSpaceGenerator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Special;

        public string GenerateSingularCharacterSpace()
        {
            return "`~!@#$%^&*()_-+={}|[]\\:\";'<>?,./";
        }
    }
}
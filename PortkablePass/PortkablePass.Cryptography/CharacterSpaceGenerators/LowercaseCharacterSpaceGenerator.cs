using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class LowercaseCharacterSpaceGenerator : ISingularCharacterSpaceGenerator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Lowercase;

        public string GenerateSingularCharacterSpace()
        {
            return @"abcdefghijklmnopqrstuvwxyz";
        }
    }
}
using System.Linq;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class DigitCharacterSpaceGenerator : ISingularCharacterSpaceGenerator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        public CharacterSpace SpaceIdentifier => CharacterSpace.Digits;

        public string GenerateSingularCharacterSpace()
        {
            return string.Join(string.Empty, Enumerable.Range(0, 10).ToArray());
        }
    }
}
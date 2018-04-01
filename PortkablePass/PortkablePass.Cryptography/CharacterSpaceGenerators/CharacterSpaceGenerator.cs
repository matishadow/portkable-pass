using System.Collections.Generic;
using System.Text;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;

namespace PortkablePass.Cryptography.CharacterSpaceGenerators
{
    public class CharacterSpaceGenerator : ICharacterSpaceGenerator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private readonly IEnumerable<ISingularCharacterSpaceGenerator> singularCharacterSpaceGenerators;

        public CharacterSpaceGenerator(IEnumerable<ISingularCharacterSpaceGenerator> singularCharacterSpaceGenerators)
        {
            this.singularCharacterSpaceGenerators = singularCharacterSpaceGenerators;
        }

        public string GenerateCharacterSpace(CharacterSpace characterSpace)
        {
            var stringBuilder = new StringBuilder();

            foreach (ISingularCharacterSpaceGenerator generator in singularCharacterSpaceGenerators)
                if (characterSpace.HasFlag(generator.SpaceIdentifier))
                    stringBuilder.Append(generator.GenerateSingularCharacterSpace());

            return stringBuilder.ToString();
        }
    }
}
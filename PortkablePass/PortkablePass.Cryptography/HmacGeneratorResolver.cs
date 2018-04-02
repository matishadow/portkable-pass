using System;
using System.Collections.Generic;
using System.Linq;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;

namespace PortkablePass.Cryptography
{
    public class HmacGeneratorResolver : IHmacGeneratorResolver,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private readonly IEnumerable<IHmacGenerator> hmacGenerators;

        public HmacGeneratorResolver(IEnumerable<IHmacGenerator> hmacGenerators)
        {
            this.hmacGenerators = hmacGenerators;
        }

        public IHmacGenerator ResolverHmacGenerator(HmacGenerator hmacGenerator)
        {
            return hmacGenerators.Single(h => h.HmacGenerator == hmacGenerator);
        }
    }
}
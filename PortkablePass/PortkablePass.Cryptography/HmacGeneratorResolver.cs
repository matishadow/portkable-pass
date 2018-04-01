using System;
using System.Collections.Generic;
using System.Linq;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Cryptography
{
    public class HmacGeneratorResolver : IHmacGeneratorResolver
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
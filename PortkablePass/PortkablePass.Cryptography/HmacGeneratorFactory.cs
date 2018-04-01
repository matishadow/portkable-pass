using System;
using System.Collections.Generic;
using System.Linq;
using PortkablePass.Enums;
using PortkablePass.Interfaces.Cryptography;

namespace PortkablePass.Cryptography
{
    public class HmacGeneratorFactory : IHmacGeneratorFactory
    {
        private readonly IEnumerable<IHmacGenerator> hmacGenerators;

        public HmacGeneratorFactory(IEnumerable<IHmacGenerator> hmacGenerators)
        {
            this.hmacGenerators = hmacGenerators;
        }

        public IHmacGenerator CreateHmacGenerator(HmacGenerator hmacGenerator)
        {
            IHmacGenerator generator = hmacGenerators.Single(h => h.HmacGenerator == hmacGenerator);

            return Activator.CreateInstance(generator.GetType()) as IHmacGenerator;
        }
    }
}
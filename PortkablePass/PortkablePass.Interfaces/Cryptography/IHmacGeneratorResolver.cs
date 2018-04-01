using PortkablePass.Enums;

namespace PortkablePass.Interfaces.Cryptography
{
    public interface IHmacGeneratorResolver
    {
        IHmacGenerator ResolverHmacGenerator(HmacGenerator hmacGenerator);
    }
}
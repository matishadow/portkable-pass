using PortkablePass.Enums;

namespace PortkablePass.Interfaces.Cryptography
{
    public interface IHmacGeneratorFactory
    {
        IHmacGenerator CreateHmacGenerator(HmacGenerator hmacGenerator);
    }
}
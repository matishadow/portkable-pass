using PortkablePass.Enums;

namespace PortkablePass.Interfaces.Cryptography
{
    public interface IHmacGenerator
    {
        byte[] GenerateHmacHash(byte[] input, byte[] key);
        byte[] GenerateHmacHash(string input, byte[] key);
        byte[] GenerateHmacHash(byte[] input, string key);
        byte[] GenerateHmacHash(string input, string key);
        HmacGenerator HmacGenerator { get; }
    }
}
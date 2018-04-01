namespace PortkablePass.Interfaces.Cryptography
{
    public interface IHmacGenerator
    {
        byte[] GenerateHmacHash(byte[] input, byte[] key);
        byte[] GenerateHmacHash(string input, byte[] key);
    }
}
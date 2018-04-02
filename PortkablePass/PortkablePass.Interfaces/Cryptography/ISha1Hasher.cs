namespace PortkablePass.Interfaces.Cryptography
{
    public interface ISha1Hasher
    {
        string ComputeStringHash(string input);
    }
}
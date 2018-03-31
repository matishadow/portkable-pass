namespace PortkablePass.Interfaces.Encoding
{
    public interface IHmacToArbitraryEncodingConverter
    {
        string ConvertToArbitraryEncodedString(byte[] input, string encoding);
    }
}
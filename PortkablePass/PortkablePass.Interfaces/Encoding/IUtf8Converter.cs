namespace PortkablePass.Interfaces.Encoding
{
    public interface IUtf8Converter
    {
        byte[] ConvertToBytes(string input);
    }
}
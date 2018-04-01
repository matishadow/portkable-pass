namespace PortkablePass.Interfaces.Encoding
{
    public interface IPasswordTruncator
    {
        string Truncate(string password, int desiredLength);
    }
}
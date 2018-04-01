using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Encoding
{
    public class PasswordTruncator : IPasswordTruncator
    {
        private const int PasswordStartingPosition = 0;

        public string Truncate(string password, int desiredLength)
        {
            return password?.Substring(PasswordStartingPosition, desiredLength);
        }
    }
}
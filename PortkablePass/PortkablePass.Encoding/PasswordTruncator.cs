using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Encoding
{
    public class PasswordTruncator : IPasswordTruncator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        private const int PasswordStartingPosition = 0;

        public string Truncate(string password, int desiredLength)
        {
            return password?.Substring(PasswordStartingPosition, desiredLength);
        }
    }
}
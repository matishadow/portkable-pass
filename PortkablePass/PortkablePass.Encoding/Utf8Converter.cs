using System;
using PortkablePass.Interfaces.Dependencies.RegistrationRelated;
using PortkablePass.Interfaces.Dependencies.ScopeRelated;
using PortkablePass.Interfaces.Encoding;

namespace PortkablePass.Encoding
{
    public class Utf8Converter : IUtf8Converter,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency
    {
        public byte[] ConvertToBytes(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentException();

            return System.Text.Encoding.UTF8.GetBytes(input);
        }
    }
}
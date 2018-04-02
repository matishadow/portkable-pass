using System;
using PortkablePass.Enums;

namespace PortkablePass.Web.Models
{
    public class PasswordGeneration
    {
        public string DomainName { get; set; }
        public string MasterPassword { get; set; }
        public string GeneratedPassword { get; set; }
        public int PasswordLength { get; set; }

        public HmacGenerator HashFunction { get; set; }
        public CharacterSpace CharacterSpace { get; set; }
    }
}
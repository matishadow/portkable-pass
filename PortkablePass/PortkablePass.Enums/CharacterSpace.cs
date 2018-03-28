using System;

namespace PortkablePass.Enums
{
    [Flags]
    public enum CharacterSpace
    {
        Lowercase = 1 << 0,
        Uppercase = 1 << 2,
        Digits = 1 << 3,
        Special = 1 << 4
    }
}

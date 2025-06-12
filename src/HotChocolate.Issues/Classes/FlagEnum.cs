using System;

namespace HotChocolate.Issues.Classes
{
    [Flags]
    public enum FlagEnum
    {
        None = 0,
        BOB = 2,
        ANA = 4,
        CLAIRE = 8,
        All = 0xF
    }
}

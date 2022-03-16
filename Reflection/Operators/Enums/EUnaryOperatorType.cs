using System;

namespace ESparrow.Utils.Reflection.Operators.Enums
{
    [Flags]
    public enum EUnaryOperatorType
    {
        UnaryPlus = 1, // +x
        UnaryNegation = 2, // -x
        LogicalNot = 4, // !x
        Increment = 8, // ++x / x++
        Decrement = 16, // --x / x--
        True = 32, // if (x) ...
        False = 64, // if (!x) ...
        Implicit = 128, // x = y // where y is T
        Explicit = 256 // (T) x
    }
}
using System;

namespace ESparrow.Utils.Reflection.Operators.Enums
{
    [Flags]
    public enum EOperatorType
    {
        Unary = 1, // ?x / x?
        Binary = 2, // x ? y
        
        All = Unary & Binary,
        Any = Unary | Binary
    }
}

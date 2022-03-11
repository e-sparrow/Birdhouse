using System;
using ESparrow.Utils.Reflection.Operators.Enums;

namespace ESparrow.Utils.Reflection.Operators.Interfaces
{
    public interface IBinaryOperatorInfo : IOperatorInfo
    {   
        object Invoke(object subject, object anotherArgument);
        
        EBinaryOperatorType BinaryOperatorType
        {
            get;
        }

        Type AnotherArgumentType
        {
            get;
        }
    }
}

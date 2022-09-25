using System;
using Birdhouse.Common.Reflection.Operators.Enums;

namespace Birdhouse.Common.Reflection.Operators.Interfaces
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

using System;
using ESparrow.Utils.Reflection.Operators.Enums;

namespace ESparrow.Utils.Reflection.Operators.Interfaces
{
    public interface IOperatorInfo
    {
        EOperatorType OperatorType
        {
            get;
        }
        
        Type ReturnType
        {
            get;
        }
    }
}

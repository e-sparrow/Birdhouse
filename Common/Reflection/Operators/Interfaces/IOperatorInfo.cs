using System;
using Birdhouse.Common.Reflection.Operators.Enums;

namespace Birdhouse.Common.Reflection.Operators.Interfaces
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

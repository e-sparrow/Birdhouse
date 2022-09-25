using System;
using Birdhouse.Common.Reflection.Operators.Enums;
using Birdhouse.Common.Reflection.Operators.Interfaces;

namespace Birdhouse.Common.Reflection.Operators
{
    public abstract class OperatorInfoBase : IOperatorInfo
    {
        protected OperatorInfoBase(EOperatorType operatorType, Type returnType)
        {
            OperatorType = operatorType;
            ReturnType = returnType;
        }

        public EOperatorType OperatorType
        {
            get;
        }
        
        public Type ReturnType
        {
            get;
        }
    }
}

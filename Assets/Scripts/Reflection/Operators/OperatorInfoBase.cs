using System;
using ESparrow.Utils.Reflection.Operators.Enums;
using ESparrow.Utils.Reflection.Operators.Interfaces;

namespace ESparrow.Utils.Reflection.Operators
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

using System;
using ESparrow.Utils.Exceptions;
using ESparrow.Utils.Reflection.Operators.Enums;
using ESparrow.Utils.Reflection.Operators.Interfaces;

namespace ESparrow.Utils.Reflection.Operators
{
    public class UnaryOperatorInfo : OperatorInfoBase, IUnaryOperatorInfo
    {
        public UnaryOperatorInfo(Type returnType, EUnaryOperatorType unaryOperatorType) : base(EOperatorType.Unary, returnType)
        {
            UnaryOperatorType = unaryOperatorType;
        }

        public object Invoke(object subject)
        {
            var type = subject.GetType();
            var method = type.GetMethod($"op_{UnaryOperatorType.ToString()}");
            
            if (method == null)
                throw new WtfException("Operator doesn't exist", this);
            
            var result = method.Invoke(subject, null);
            
            if (result == null)
                throw new WtfException("Return type is void", this);
            
            if (result.GetType() != ReturnType)
                throw new WtfException("Wrong return type invocation", this);
            
            return result;
        }
        
        public EUnaryOperatorType UnaryOperatorType
        {
            get;
        }
    }
}
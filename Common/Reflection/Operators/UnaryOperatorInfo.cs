using System;
using System.Linq;
using Birdhouse.Common.Exceptions;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Operators.Enums;
using Birdhouse.Common.Reflection.Operators.Interfaces;

namespace Birdhouse.Common.Reflection.Operators
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
            
            var result = method.Invoke(subject, subject.AsSingleEnumerable().ToArray());
            
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
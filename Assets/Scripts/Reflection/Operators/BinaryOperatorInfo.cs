using System;
using ESparrow.Utils.Exceptions;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Reflection.Operators.Enums;
using ESparrow.Utils.Reflection.Operators.Interfaces;

namespace ESparrow.Utils.Reflection.Operators
{
    public class BinaryOperatorInfo : OperatorInfoBase, IBinaryOperatorInfo
    {
        public BinaryOperatorInfo(Type returnType, EBinaryOperatorType binaryOperatorType, Type anotherArgumentType) : base(EOperatorType.Binary, returnType)
        {
            BinaryOperatorType = binaryOperatorType;
            AnotherArgumentType = anotherArgumentType;
        }

        public object Invoke(object subject, object anotherArgument)
        {
            if (anotherArgument.GetType() != AnotherArgumentType)
                throw new WtfException("Wrong argument type invocation");
            
            var type = subject.GetType();
            var method = type.GetMethod($"op_{BinaryOperatorType.ToString()}");

            if (method == null)
                throw new WtfException("Operator doesn't exist");
            
            var result = method.Invoke(subject, anotherArgument as object[]);

            if (result == null)
                throw new WtfException("Return type is void");
            
            if (result.GetType() != ReturnType)
                throw new WtfException("Wrong return type invocation");
            
            return result;
        }

        public EBinaryOperatorType BinaryOperatorType
        {
            get;
        }

        public Type AnotherArgumentType
        {
            get;
        }
    }
}

using ESparrow.Utils.Reflection.Operators.Enums;

namespace ESparrow.Utils.Reflection.Operators.Interfaces
{
    public interface IUnaryOperatorInfo : IOperatorInfo
    {
        object Invoke(object subject);
        
        EUnaryOperatorType UnaryOperatorType
        {
            get;
        }
    }
}

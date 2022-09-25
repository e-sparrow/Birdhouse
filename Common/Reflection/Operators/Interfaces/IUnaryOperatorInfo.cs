using Birdhouse.Common.Reflection.Operators.Enums;

namespace Birdhouse.Common.Reflection.Operators.Interfaces
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

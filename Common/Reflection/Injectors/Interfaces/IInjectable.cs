using System.Reflection;

namespace Birdhouse.Common.Reflection.Injectors.Interfaces
{
    public interface IInjectable
    {
        bool IsFit(ParameterInfo parameter);
        object GetValue();
    }
}
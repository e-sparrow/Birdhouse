using System.Reflection;
using Birdhouse.Common.Reflection.Injectors.Interfaces;

namespace Birdhouse.Common.Reflection.Injectors
{
    public abstract class InjectableBase : IInjectable
    {
        public abstract bool IsFit(ParameterInfo parameter);
        public abstract object GetValue();
    }
}
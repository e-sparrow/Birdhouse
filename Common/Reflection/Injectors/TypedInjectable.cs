using System;
using System.Reflection;

namespace Birdhouse.Common.Reflection.Injectors
{
    public class TypedInjectable<T> : InjectableBase
    {
        public TypedInjectable(Func<T> valueFunction)
        {
            _valueFunction = valueFunction;
        }

        private readonly Func<T> _valueFunction;

        public override bool IsFit(ParameterInfo parameter)
        {
            var result = parameter.ParameterType == typeof(T);
            return result;
        }

        public override object GetValue()
        {
            var result = _valueFunction.Invoke();
            return result;
        }
    }
}
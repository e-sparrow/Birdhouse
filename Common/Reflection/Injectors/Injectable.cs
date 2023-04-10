using System;
using System.Reflection;

namespace Birdhouse.Common.Reflection.Injectors
{
    public class Injectable : InjectableBase
    {
        public Injectable(Func<bool> condition, Func<object> valueFunction)
        {
            _condition = condition;
            _valueFunction = valueFunction;
        }
        
        private readonly Func<bool> _condition;
        private readonly Func<object> _valueFunction;
        
        public override bool IsFit(ParameterInfo parameter)
        {
            var result = _condition.Invoke();
            return result;
        }

        public override object GetValue()
        {
            var result = _valueFunction.Invoke();
            return result;
        }
    }
}
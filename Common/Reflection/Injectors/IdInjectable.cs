using System;
using System.Collections.Generic;
using System.Reflection;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.Injectors.Attributes;

namespace Birdhouse.Common.Reflection.Injectors
{
    public class IdInjectable<T> : InjectableBase
    {
        public IdInjectable(string id, Func<T> valueFunction)
        {
            _id = id;
            _valueFunction = valueFunction;
        }

        private readonly string _id;
        private readonly Func<T> _valueFunction;
        
        public override bool IsFit(ParameterInfo parameter)
        {
            if (parameter.ParameterType != typeof(T))
            {
                return false;
            }

            if (parameter.TryGetCustomAttribute<InjectableIdAttribute>(out var attribute))
            {
                if (attribute.Id != _id)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public override object GetValue()
        {
            var result = _valueFunction.Invoke();
            return result;
        }
    }
}
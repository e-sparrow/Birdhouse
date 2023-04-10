using System;
using System.Collections.Generic;
using System.Reflection;
using Birdhouse.Common.Reflection.Injectors.Interfaces;

namespace Birdhouse.Common.Reflection.Injectors
{
    public abstract class InjectorBase : IInjector
    {
        public bool TryInject(Type type, out object result)
        {
            result = null;

            var parametersList = new List<object>();

            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();

                var isRight = true;
                foreach (var parameter in parameters)
                {
                    if (TryGetParameterResult(parameter, out var parameterValue))
                    {
                        parametersList.Add(parameterValue);
                    }
                    else
                    {
                        isRight = false;
                        parametersList.Clear();
                        
                        break;
                    }
                }

                if (isRight)
                {
                    result = constructor.Invoke(parametersList.ToArray());
                    return true;
                }
            }

            return false;
        }

        protected abstract bool TryGetParameterResult(ParameterInfo parameter, out object result);
    }
}
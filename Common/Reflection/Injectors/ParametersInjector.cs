using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Reflection.Injectors.Interfaces;

namespace Birdhouse.Common.Reflection.Injectors
{
    public class ParametersInjector : InjectorBase
    {
        public ParametersInjector(IEnumerable<IInjectable> parameters)
        {
            _parameters = parameters;
        }

        private readonly IEnumerable<IInjectable> _parameters;

        protected override bool TryGetParameterResult(ParameterInfo parameter, out object result)
        {
            result = null;
            
            var injectable = _parameters.FirstOrDefault(value => value.IsFit(parameter));

            var isFit = injectable != null;
            if (isFit)
            {
                result = injectable.GetValue();
            }

            return isFit;
        }
    }
}
 
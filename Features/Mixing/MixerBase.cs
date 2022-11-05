using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Mixing.Interfaces;
using Birdhouse.Tools.Interpolation.Interfaces;

namespace Birdhouse.Features.Mixing
{
    public abstract class MixerBase<T> : IMixer<T>
    {
        protected MixerBase(IInterpolator<T> interpolator)
        {
            _interpolator = interpolator;
        }

        private readonly IInterpolator<T> _interpolator;

        protected abstract IMixingPart<T> Mix(IInterpolator<T> interpolator, IMixingPart<T> first, IMixingPart<T> second);

        public T Mix(IEnumerable<IMixingPart<T>> parts)
        {
            var array = parts.ToArray();
            
            var result = array.First();
            foreach (var part in array.Without(result))
            {
                result = Mix(_interpolator, result, part);
            }

            return result.Value;
        }
    }
}
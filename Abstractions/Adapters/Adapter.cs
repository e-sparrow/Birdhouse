using Birdhouse.Abstractions.Adapters.Interfaces;
using Birdhouse.Common.Delegates;

namespace Birdhouse.Abstractions.Adapters
{
    public class Adapter<TTo>
        : IAdapter<TTo>
    {
        public Adapter(ConditionalFunc<object, TTo> func)
        {
            _func = func;
        }

        private readonly ConditionalFunc<object, TTo> _func;
        
        public bool TryAdapt(object value, out TTo result)
        {
            var canAdapt = _func.Invoke(value, out result);
            return canAdapt;
        }
    }
}
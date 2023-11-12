using System;

namespace Birdhouse.Common.Collections
{
    public class LazyBuffer<TKey, TValue> 
        : LazyBufferBase<TKey, TValue>
    {
        public LazyBuffer(Func<TKey, TValue> func)
        {
            _func = func;
        }

        private readonly Func<TKey, TValue> _func;

        protected override TValue CreateValue(TKey key)
        {
            var result = _func.Invoke(key);
            return result;
        }
    }
}
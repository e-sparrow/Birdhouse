using System;
using System.Collections.Generic;

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

    public class LazyDictionary<TKey, TValue>
        : LazyBufferBase<TKey, TValue>
    {
        public LazyDictionary(IDictionary<TKey, Func<TValue>> funcs)
        {
            _funcs = funcs;
        }

        private readonly IDictionary<TKey, Func<TValue>> _funcs;
        
        protected override TValue CreateValue(TKey key)
        {
            var result = _funcs[key].Invoke();
            return result;
        }
    }
}
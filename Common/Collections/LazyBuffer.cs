using System;
using System.Collections.Generic;
using Birdhouse.Common.Delegates;

namespace Birdhouse.Common.Collections
{
    public class LazyBuffer<TKey, TValue> 
        : LazyBufferBase<TKey, TValue>
    {
        public LazyBuffer(Func<TKey, TValue> func) => _func = func;
        
        private readonly Func<TKey, TValue> _func;
        
        protected override TValue CreateValue(TKey key) => _func.Invoke(key);
    }

    public sealed class ConditionalLazyBuffer<TKey, TValue>
        : ConditionalLazyBufferBase<TKey, TValue>
    {
        public ConditionalLazyBuffer(ConditionalFunc<TKey, TValue> func) => _func = func;

        private readonly ConditionalFunc<TKey, TValue> _func;

        protected override bool TryCreateValue(TKey key, out TValue result) => _func.Invoke(key, out result);
    }

    public class LazyDictionary<TKey, TValue>
        : LazyBufferBase<TKey, TValue>
    {
        public LazyDictionary(IDictionary<TKey, Func<TValue>> funcs) => _funcs = funcs;

        private readonly IDictionary<TKey, Func<TValue>> _funcs;

        protected override TValue CreateValue(TKey key) => _funcs[key].Invoke();
    }

    public class ConditionalLazyDictionary<TKey, TValue>
        : ConditionalLazyBufferBase<TKey, TValue>
    {
        public ConditionalLazyDictionary(IDictionary<TKey, ConditionalFunc<TValue>> funcs) => _funcs = funcs;

        private readonly IDictionary<TKey, ConditionalFunc<TValue>> _funcs;

        protected override bool TryCreateValue(TKey key, out TValue result) => _funcs[key].Invoke(out result);
    }
}
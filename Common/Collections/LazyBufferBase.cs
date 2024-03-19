using System.Collections.Generic;
using Birdhouse.Common.Collections.Interfaces;

namespace Birdhouse.Common.Collections
{
    public abstract class LazyBufferBase<TKey, TValue> 
        : ILazyBuffer<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        protected abstract TValue CreateValue(TKey key);
        
        public TValue GetOrCreate(TKey key)
        {
            var hasValue = _dictionary.TryGetValue(key, out var value);
            if (hasValue)
            {
                return value;
            }

            value = CreateValue(key);
            _dictionary.Add(key, value);

            return value;
        }
    }
}
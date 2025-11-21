using System.Collections;
using System.Collections.Generic;
using Birdhouse.Common.Collections.Abstractions;

namespace Birdhouse.Common.Collections
{
    public abstract class LazyBufferBase<TKey, TValue> 
        : ILazyBuffer<TKey, TValue>
    {
        public TValue this[TKey key] => GetOrCreate(key);
        
        private readonly IDictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        protected abstract TValue CreateValue(TKey key);
        
        public TValue GetOrCreate(TKey key)
        {
            var hasValue = _dictionary.TryGetValue(key, out var value);
            if (hasValue) return value;

            value = CreateValue(key);
            _dictionary.Add(key, value);

            return value;
        }

        public void UpdateValue(TKey key, TValue value) => _dictionary[key] = value;
        public void UpdateKey(TKey key) => GetOrCreate(key);
        public void RemoveKey(TKey key) => _dictionary.Remove(key);

        public bool EnsureKey(TKey key)
        {
            if (!_dictionary.ContainsKey(key))
                UpdateKey(key);

            return true;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public abstract class ConditionalLazyBufferBase<TKey, TValue>
        : IConditionalLazyBuffer<TKey, TValue>
    {
        public TValue this[TKey key]
        {
            get
            {
                var hasValue = TryGetOrCreate(key, out var result);
                return hasValue ? result : default;
            }
        }

        private readonly IDictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        protected abstract bool TryCreateValue(TKey key, out TValue result);

        public bool TryGetOrCreate(TKey key, out TValue result)
        {
            result = default;
            
            var hasValue = _dictionary.TryGetValue(key, out result);
            if (hasValue) return true;

            hasValue = TryCreateValue(key, out result);
            if (!hasValue) return false;
            
            _dictionary.Add(key, result);
            return true;
        }

        public void UpdateValue(TKey key, TValue value) => _dictionary[key] = value;
        public void UpdateKey(TKey key) => TryGetOrCreate(key, out _);
        public void RemoveKey(TKey key) => _dictionary.Remove(key);

        public bool EnsureKey(TKey key)
        {
            if (!_dictionary.ContainsKey(key))
                UpdateKey(key);

            return _dictionary.ContainsKey(key);
        }
        
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
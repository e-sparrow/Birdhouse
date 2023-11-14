using System;
using System.Collections;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public class RegistryDictionary<TKey, TValue>
        : IRegistryDictionary<TKey, TValue>
    {
        public TValue this[TKey key] => _dictionary[key];
        
        public bool TryGetValue(TKey key, out TValue value)
        {
            var result = _dictionary.TryGetValue(key, out value);
            return result;
        }

        public bool ContainsKey(TKey key)
        {
            var result = _dictionary.ContainsKey(key);
            return result;
        }

        private readonly IDictionary<TKey, TValue> _dictionary 
            = new Dictionary<TKey, TValue>();

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            var result = _dictionary.GetEnumerator();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IDisposable Register(TKey key, TValue value)
        {
            var result = _dictionary.AddAsDisposable(key, value);
            return result;
        }

        public IDisposable Register(KeyValuePair<TKey, TValue> element)
        {
            var result = _dictionary.AddAsDisposable(element);
            return result;
        }

        public void Dispose()
        {
            _dictionary.Clear();
        }
    }
}
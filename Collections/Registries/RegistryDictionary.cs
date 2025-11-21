using System;
using System.Collections;
using System.Collections.Generic;
using Birdhouse.Collections.Registries.Abstractions;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Collections.Registries
{
    public class RegistryDictionary<TKey, TValue>
        : IRegistryDictionary<TKey, TValue>
    {
        public TValue this[TKey key] => _dictionary[key];

        private readonly IDictionary<TKey, TValue> _dictionary 
            = new Dictionary<TKey, TValue>();

        public bool TryGetValue(TKey key, out TValue value) => _dictionary.TryGetValue(key, out value);
        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IDisposable Register(TKey key, TValue value) => _dictionary.AddAsDisposable(key, value);
        public IDisposable Register(KeyValuePair<TKey, TValue> element) => _dictionary.AddAsDisposable(element);
        public void Dispose() => _dictionary.Clear();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Collections.Registries
{
    public sealed class NestedRegistryDictionary<TKey, TValue>
        : INestedRegistryDictionary<TKey, TValue>
    {
        public IRegistryEnumerable<TValue> this[TKey key] => _inner[key];
        
        private readonly IDictionary<TKey, IDisposable> _registryTokens 
            = new Dictionary<TKey, IDisposable>();

        private readonly IRegistryDictionary<TKey, IRegistryEnumerable<TValue>> _inner 
            = new RegistryDictionary<TKey, IRegistryEnumerable<TValue>>();

        public IDisposable Register(KeyValuePair<TKey, IRegistryEnumerable<TValue>> element) => _inner.Register(element);

        public IDisposable Register(KeyValuePair<TKey, TValue> element)
        {
            var hasRegistry = _inner.TryGetValue(element.Key, out var registry);
            if (!hasRegistry)
            {
                registry = new RegistryEnumerable<TValue>();
                var registryToken = _inner.Register(element.Key, registry);
                _registryTokens.Add(element.Key, registryToken);
            }

            var token = new CompositeDisposable();
            token.Append(registry.Register(element.Value));
            
            // TODO: Maybe create a single callback exemplar and place it into every token?
            token.Append(new CallbackDisposable(CheckForEmptiness));
            
            return token;

            void CheckForEmptiness()
            {
                if (!registry.Any())
                {
                    var target = _registryTokens[element.Key];
                    _registryTokens.Remove(element.Key);
                    
                    target.Dispose();
                }
            }
        }

        public IDisposable Register(TKey key, TValue value) => Register(new KeyValuePair<TKey, TValue>(key, value));

        public void Dispose()
        {
            _registryTokens.Clear();
            _inner.Dispose();
        }

        public IEnumerator<KeyValuePair<TKey, IRegistryEnumerable<TValue>>> GetEnumerator() => _inner.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IDisposable Register(TKey key, IRegistryEnumerable<TValue> value) => Register(new KeyValuePair<TKey, IRegistryEnumerable<TValue>>(key, value));
        public bool TryGetValue(TKey key, out IRegistryEnumerable<TValue> value) => _inner.TryGetValue(key, out value);
        public bool ContainsKey(TKey key) => _inner.ContainsKey(key);
    }
}
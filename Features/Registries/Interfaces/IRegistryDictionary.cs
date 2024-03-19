using System;
using System.Collections.Generic;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IRegistryDictionary<TKey, TValue, out TToken>
        : IRegistryEnumerable<KeyValuePair<TKey, TValue>>
        where TToken : IDisposable
    {
        TValue this[TKey key]
        {
            get;
        }

        TToken Register(TKey key, TValue value);

        bool TryGetValue(TKey key, out TValue value);
        bool ContainsKey(TKey key);
    }

    public interface IRegistryDictionary<TKey, TValue>
        : IRegistryDictionary<TKey, TValue, IDisposable>
    {
        
    }
}
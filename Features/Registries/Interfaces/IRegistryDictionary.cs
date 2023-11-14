using System;
using System.Collections.Generic;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IRegistryDictionary<TKey, TValue>
        : IRegistryEnumerable<KeyValuePair<TKey, TValue>>
    {
        TValue this[TKey key]
        {
            get;
        }

        IDisposable Register(TKey key, TValue value);

        bool TryGetValue(TKey key, out TValue value);
        bool ContainsKey(TKey key);
    }
}
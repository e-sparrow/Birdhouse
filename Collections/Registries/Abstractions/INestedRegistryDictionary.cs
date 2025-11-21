using System;
using System.Collections.Generic;

namespace Birdhouse.Collections.Registries.Abstractions
{
    public interface INestedRegistryDictionary<TKey, TValue>
        : IRegistryDictionary<TKey, IRegistryEnumerable<TValue>>, IRegistry<KeyValuePair<TKey, TValue>>
    {
        IDisposable Register(TKey key, TValue value);
    }
}
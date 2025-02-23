using System;
using System.Collections.Generic;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface INestedRegistryDictionary<TKey, TValue>
        : IRegistryDictionary<TKey, IRegistryEnumerable<TValue>>, IRegistry<KeyValuePair<TKey, TValue>>
    {
        IDisposable Register(TKey key, TValue value);
    }
}
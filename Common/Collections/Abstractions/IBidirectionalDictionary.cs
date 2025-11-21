using System.Collections.Generic;

namespace Birdhouse.Common.Collections.Abstractions
{
    public interface IBidirectionalDictionary<TKey, TValue>
        : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        TKey this[TValue value]
        {
            get;
        }

        TValue this[TKey key]
        {
            get;
        }

        bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
    }
}
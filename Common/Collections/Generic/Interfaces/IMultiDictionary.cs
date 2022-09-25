using System.Collections.Generic;

namespace Birdhouse.Common.Collections.Generic.Interfaces
{
    public interface IMultiDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>>
    {
        void Add(TKey key, TValue value);
        bool Remove(TKey key, TValue value);
    }
}

using System.Collections.Generic;

namespace Birdhouse.Common.Collections.Abstractions
{
    public interface ILazyBuffer<TKey, TValue>
        : IWriteOnlyLazyBuffer<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        TValue this[TKey key]
        {
            get;
        }

        TValue GetOrCreate(TKey key);
    }

    public interface IConditionalLazyBuffer<TKey, TValue>
        : IWriteOnlyLazyBuffer<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        TValue this[TKey key]
        {
            get;
        }

        bool TryGetOrCreate(TKey key, out TValue result);
    }

    public interface IWriteOnlyLazyBuffer<in TKey, in TValue>
    {
        void UpdateValue(TKey key, TValue value);
        void UpdateKey(TKey key);
        void RemoveKey(TKey key);
        bool EnsureKey(TKey key);
    }
}
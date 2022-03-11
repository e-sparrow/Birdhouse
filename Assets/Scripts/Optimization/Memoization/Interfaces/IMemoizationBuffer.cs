using System;

namespace ESparrow.Utils.Optimization.Memoization.Interfaces
{
    public interface IMemoizationBuffer<in TKey, TValue>
    {
        TValue GetOrCreate(TKey key, Func<TValue> create);
    }
}
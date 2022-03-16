using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization.Interfaces
{
    public interface IMemoizationBuffer<in TKey, TValue>
    {
        TValue GetOrCreate(TKey key, Func<TValue> create);
        TValue GetOrCreate(TKey key, Func<TValue> create, ITerm term);

        void Check();
    }
}
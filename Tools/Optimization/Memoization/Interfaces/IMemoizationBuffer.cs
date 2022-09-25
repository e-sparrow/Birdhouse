using System;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization.Interfaces
{
    public interface IMemoizationBuffer<in TKey, TValue>
    {
        TValue GetOrCreate(TKey key, Func<TValue> create);
        TValue GetOrCreate(TKey key, Func<TValue> create, ITerm term);

        void Check();
    }
}
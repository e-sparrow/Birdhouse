using System;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization.Interfaces
{
    public interface IBufferContainer<in TKey>
    {
        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key);
        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, TimeSpan elementLifetime);
        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, Func<ITermInfo> termInfoCreator);
    }
} 
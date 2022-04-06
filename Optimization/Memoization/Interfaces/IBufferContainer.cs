using System;
using ESparrow.Utils.Tools.Tense.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization.Interfaces
{
    public interface IBufferContainer<in TKey>
    {
        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key);
        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, TimeSpan elementLifetime);
        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, Func<ITermInfo> termInfoCreator);
    }
} 
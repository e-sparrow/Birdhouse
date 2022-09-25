using System;
using Birdhouse.Tools.Optimization.Memoization;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public static class MemoizationHelper
    {
        public static readonly IBufferContainer<Type> Container = new BufferContainer<Type>();

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>()
        {
            return new MemoizationBuffer<TKey, TValue>(TenseHelper.Terms.CreateTermInfo);
        }

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>(TimeSpan elementLifetime)
        {
            return new MemoizationBuffer<TKey, TValue>(CreateTermInfoWithLifetime);

            ITermInfo CreateTermInfoWithLifetime()
            {
                return TenseHelper.Terms.CreateTermInfo(elementLifetime);
            }
        }

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>(Func<ITermInfo> termInfoCreator)
        {
            return new MemoizationBuffer<TKey, TValue>(termInfoCreator);
        }
    }
}
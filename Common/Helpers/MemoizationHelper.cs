using System;
using Birdhouse.Tools.Optimization.Memoization;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public static class MemoizationHelper
    {
        public static readonly IBufferContainer<Type> Container = new BufferContainer<Type>();

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>()
        {
            var result = new MemoizationBuffer<TKey, TValue>(TermHelper.CreateTermInfo);
            return result;
        }

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>(TimeSpan elementLifetime)
        {
            var result = new MemoizationBuffer<TKey, TValue>(CreateTermInfoWithLifetime);
            return result;

            ITermInfo CreateTermInfoWithLifetime()
            {
                var info = TermHelper.CreateTermInfo(elementLifetime);
                return info;
            }
        }

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>(Func<ITermInfo> termInfoCreator)
        {
            var result = new MemoizationBuffer<TKey, TValue>(termInfoCreator);
            return result;
        }
    }
}
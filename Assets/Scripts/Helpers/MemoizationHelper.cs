using System;
using ESparrow.Utils.Optimization.Memoization;
using ESparrow.Utils.Optimization.Memoization.Interfaces;
using ESparrow.Utils.Tools.DateAndTime.Expiration;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Helpers
{
    public static class MemoizationHelper
    {
        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>()
        {
            return new MemoizationBuffer<TKey, TValue>(CreateTermInfo);
        }

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>(TimeSpan elementLifetime)
        {
            return new MemoizationBuffer<TKey, TValue>(CreateTermInfoWithLifetime);

            ITermInfo CreateTermInfoWithLifetime()
            {
                return CreateTermInfo(elementLifetime);
            }
        }

        public static IMemoizationBuffer<TKey, TValue> CreateBuffer<TKey, TValue>(Func<ITermInfo> termInfoCreator)
        {
            return new MemoizationBuffer<TKey, TValue>(termInfoCreator);
        }

        public static ITermInfo CreateTermInfo()
        {
            return new TermInfo();
        }

        public static ITermInfo CreateTermInfo(TimeSpan lifetime)
        {
            return new TermInfo(GetExpirationTime());

            DateTime GetExpirationTime()
            {
                return DateTime.Now.Add(lifetime);
            }
        }
    }
}
using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Tense.Timestamps;
using Birdhouse.Tools.Tense.Timestamps.Interfaces;

namespace Birdhouse.Tools.Tense
{
    public static class UnixHelper
    {
        public static readonly DateTime Origin = new DateTime(1970, 1, 1);

        public static long ToUnix(DateTime value)
        {
            var delta = value - Origin;
            
            var result = (long) delta.TotalSeconds;
            return result;
        }

        public static DateTime FromUnix(long value)
        {
            var result =  Origin.AddSeconds(value);
            return result;
        }

        public static ITimestamp<TimeSpan> CreateDefaultUnixTimestamp()
        {
            var tenseController = TenseHelper
                .UtcNowTenseProvider
                .Value
                .AsTimeSpanUnix();
            
            var result = new TimeSpanTimestamp(tenseController);
            return result;
        }
    }
}
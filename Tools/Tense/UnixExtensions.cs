using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense
{
    public static class UnixExtensions
    {
        public static ITenseProvider<long> AsUnix(this ITenseProvider<DateTime> tenseProvider)
        {
            var result = TenseHelper.CreateTenseController(GetCurrentTime);
            return result;

            long GetCurrentTime()
            {
                var time = tenseProvider
                    .Now()
                    .ToUnix();

                return time;
            }
        }

        public static ITenseProvider<TimeSpan> AsTimeSpanUnix(this ITenseProvider<DateTime> tenseProvider)
        {
            var result = TenseHelper.CreateTenseController(GetCurrentTime);
            return result;

            TimeSpan GetCurrentTime()
            {
                var time = tenseProvider
                    .Now()
                    .ToUnixTimeSpan();

                return time;
            }
        }
    }
}
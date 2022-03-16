using System;
using ESparrow.Utils.Extensions;
using Tools.DateAndTime.Timestamps;

namespace ESparrow.Utils.Helpers
{
    public static class DateAndTimeHelper
    {
        public static class UnixHelper
        {
            public static readonly DateTime Origin = new DateTime(1970, 1, 1);

            public static long ToUnix(DateTime value)
            {
                return (long) (value - Origin).TotalSeconds;
            }

            public static DateTime FromUnix(long value)
            {
                return Origin.AddSeconds(value);
            }

            public static Timestamp CreateDefaultUnixTimestamp()
            {
                var origin = GetCurrentTimeSpan();
                return new Timestamp(origin, GetCurrentTimeSpan);

                TimeSpan GetCurrentTimeSpan()
                {
                    return DateTime.Now.ToUnixTimeSpan();
                }
            }
        }
    }
}
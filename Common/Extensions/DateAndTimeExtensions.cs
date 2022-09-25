using System;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Common.Extensions
{
    public static class DateAndTimeExtensions
    {
        public static long ToUnix(this DateTime self)
        {
            return TenseHelper.Unix.ToUnix(self);
        }

        public static DateTime FromUnix(this long self)
        {
            return TenseHelper.Unix.FromUnix(self);
        }

        public static TimeSpan ToUnixTimeSpan(this DateTime self)
        {
            return TimeSpan.FromSeconds(self.ToUnix());
        }

        public static DateTime FromUnixTimeSpan(this TimeSpan self)
        {
            return ((long) self.TotalSeconds).FromUnix();
        }
    }
}

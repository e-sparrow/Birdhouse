using System;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Tense;

namespace Birdhouse.Common.Extensions
{
    public static class DateAndTimeExtensions
    {
        public static long ToUnix(this DateTime self)
        {
            return UnixHelper.ToUnix(self);
        }

        public static DateTime FromUnix(this long self)
        {
            return UnixHelper.FromUnix(self);
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

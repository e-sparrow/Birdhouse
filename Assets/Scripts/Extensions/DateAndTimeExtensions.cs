using System;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class DateAndTimeExtensions
    {
        public static long ToUnix(this DateTime self)
        {
            return DateAndTimeHelper.UnixHelper.ToUnix(self);
        }

        public static DateTime FromUnix(this long self)
        {
            return DateAndTimeHelper.UnixHelper.FromUnix(self);
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

using System;
using Global.Interfaces;

namespace Global
{
    public class TimeManager : ITimeManager
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
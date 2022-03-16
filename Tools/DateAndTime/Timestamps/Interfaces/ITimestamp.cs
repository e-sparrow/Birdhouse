using System;

namespace Tools.DateAndTime.Timestamps.Interfaces
{
    public interface ITimestamp
    {
        TimeSpan Stamp();

        TimeSpan LastStamp
        {
            get;
        }
    }
}
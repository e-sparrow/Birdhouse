using System;

namespace Birdhouse.Tools.Tense.Timestamps.Interfaces
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
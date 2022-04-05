using System;

namespace ESparrow.Utils.Tools.Tense.Timestamps.Interfaces
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
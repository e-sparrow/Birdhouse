using System;
using ESparrow.Utils.Patterns.Listening.Interfaces;

namespace ESparrow.Utils.Patterns.Listening
{
    public readonly struct ListenSettings : IListenSettings
    {
        public ListenSettings(TimeSpan delay, int callsCount)
        {
            Delay = delay;
            CallsCount = callsCount;
        }

        public TimeSpan Delay
        {
            get;
        }

        public int CallsCount
        {
            get;
        }
    }
}
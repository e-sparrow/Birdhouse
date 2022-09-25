using System;
using Birdhouse.Education.Patterns.Listening.Interfaces;

namespace Birdhouse.Education.Patterns.Listening
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
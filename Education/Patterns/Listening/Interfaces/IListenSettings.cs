using System;

namespace Birdhouse.Education.Patterns.Listening.Interfaces
{
    public interface IListenSettings
    {
        TimeSpan Delay
        {
            get;
        }

        int CallsCount
        {
            get;
        }
    }
}
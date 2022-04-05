using System;

namespace ESparrow.Utils.Patterns.Listening.Interfaces
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
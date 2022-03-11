using System;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces
{
    public interface ITermInfo
    {
        DateTime AbsoluteExpiration
        {
            get;
        }

        TimeSpan SlidingExpiration
        {
            get;
        }
    }
}
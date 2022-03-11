using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Enums;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces
{
    public interface ITermInfo
    {
        ETermType Type
        {
            get;
        }
        
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
using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration
{
    public class TermInfoBase : ITermInfo
    {
        public TermInfoBase(DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
        }

        public DateTime AbsoluteExpiration
        {
            get;
        }

        public TimeSpan SlidingExpiration
        {
            get;
        }
    }
}
using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Enums;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration
{
    public readonly struct TermInfo : ITermInfo
    {
        public TermInfo(ETermType type, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Type = type;
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
        }
        
        public TermInfo(ETermType type = ETermType.Eternal) 
            : this(type, default, default)
        {
            
        }
        public TermInfo(DateTime absoluteExpiration) 
            : this(ETermType.AbsoluteExpiration, absoluteExpiration, default)
        {
            
        }

        public TermInfo(TimeSpan slidingExpiration) 
            : this(ETermType.SlidingExpiration, default, slidingExpiration)
        {
            
        }

        public TermInfo(DateTime absoluteExpiration, TimeSpan slidingExpiration) 
            : this(ETermType.Combined, absoluteExpiration, slidingExpiration)
        {
            
        }

        public ETermType Type
        {
            get;
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
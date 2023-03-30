using System;
using Birdhouse.Tools.Tense.Expiration.Enums;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Tense.Expiration
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
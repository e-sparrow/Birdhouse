using System;
using ESparrow.Utils.Patterns.Builders;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration
{
    public class TermInfo : TermInfoBase
    {
        public TermInfo(DateTime absoluteExpiration, TimeSpan slidingExpiration) : base(absoluteExpiration, slidingExpiration)
        {

        }

        public static TermInfoBuilder CreateBuilder()
        {
            
        }

        public class TermInfoBuilder : BuilderBase<TermInfo>
        {
            private TermInfoBuilder() : base(new TermInfo())
            {
                
            }
            
            public TermInfoBuilder 
        }
    }
}
using System;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Tools.Tense.Timestamps
{
    public class TimeSpanTimestamp : TimestampBase<TimeSpan>
    {
        public TimeSpanTimestamp(ITenseProvider<TimeSpan> tenseProvider)
            : base(tenseProvider)
        {
            
        }

        protected override TimeSpan GetDeltaTime(TimeSpan current, TimeSpan previous)
        {
            var result = current - previous;
            return result;
        }
    }
}
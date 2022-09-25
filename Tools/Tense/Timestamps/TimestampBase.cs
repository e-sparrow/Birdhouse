using System;
using Birdhouse.Tools.Tense.Timestamps.Interfaces;

namespace Birdhouse.Tools.Tense.Timestamps
{
    public abstract class TimestampBase : ITimestamp
    {
        protected TimestampBase(TimeSpan initialTime)
        {
            LastStamp = initialTime;
        }

        protected abstract TimeSpan GetCurrentTime();
        
        public TimeSpan Stamp()
        {
            var current = GetCurrentTime();
            var delta = current.Subtract(LastStamp);
            
            LastStamp = current;

            return delta;
        }

        public TimeSpan LastStamp
        {
            get; 
            private set;
        }
    }
}

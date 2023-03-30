using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense.Timestamps
{
    public class LongTimestamp : TimestampBase<long>
    {
        public LongTimestamp(ITenseProvider<long> tenseProvider)
            : base(tenseProvider)
        {
            
        }

        protected override long GetDeltaTime(long current, long previous)
        {
            var result = current - previous;
            return result;
        }
    }
}
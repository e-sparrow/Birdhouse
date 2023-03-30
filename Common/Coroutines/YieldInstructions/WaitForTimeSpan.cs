using System;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Providers.Interfaces;
using Birdhouse.Tools.Tense.Timestamps;
using Birdhouse.Tools.Tense.Timestamps.Interfaces;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public class WaitForTimeSpan : FlowableYieldInstructionBase
    {
        public WaitForTimeSpan(TimeSpan time, ITenseProvider<TimeSpan> tenseProvider = null)
            : base((float) time.TotalSeconds)
        {
            tenseProvider ??= GetDefaultTenseController();

            var timestamp = new TimeSpanTimestamp(tenseProvider);
            _timestamp = timestamp;

            static ITenseProvider<TimeSpan> GetDefaultTenseController()
            {
                var result = TenseHelper.UtcNowTenseProvider.AsTimeSpanUnix();
                return result;
            }
        }

        private readonly ITimestamp<TimeSpan> _timestamp;

        private TimeSpan _sum = TimeSpan.Zero;

        protected override float GetProgress()
        {
            var stamp = _timestamp.Stamp();
            _sum += stamp;

            var result = (float) _sum.TotalSeconds;
            return result;
        }
    }
}
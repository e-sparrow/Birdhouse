using System;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Timestamps.Interfaces;

namespace Birdhouse.Tools.Instructions.Kinds
{
    public class DelayInstruction : InstructionBase
    {
        public DelayInstruction
        (
            ITimestamp<TimeSpan> timestamp,
            Action action, 
            Action onDestroy = default,
            TimeSpan delay = default
        ) : base(action, onDestroy)
        {
            _timestamp = timestamp;
            _delay = delay;
        }
        
        public DelayInstruction
        (
            Action action, 
            Action onDestroy = default,
            TimeSpan delay = default
        ) : this(UnixHelper.CreateDefaultUnixTimestamp(), action, onDestroy, delay)
        {
            _delay = delay;
        }

        public DelayInstruction
        (
            Action action, 
            Action onDestroy = default,
            float delay = default
        ) : this(action, onDestroy, TimeSpan.FromSeconds(delay))
        {
            
        }
        
        private readonly TimeSpan _delay;
        private readonly ITimestamp<TimeSpan> _timestamp;
        
        private TimeSpan _currentTime;

        protected override bool Check()
        {
            var delta = _timestamp.Stamp();
            
            var result = _currentTime >= _delay;
            _currentTime = result ? TimeSpan.Zero : _currentTime + delta;

            return result;
        }
    }
}

using System;
using ESparrow.Utils.Helpers;
using Tools.DateAndTime.Timestamps.Interfaces;

namespace ESparrow.Utils.Instructions.Kinds
{
    public class DelayInstruction : InstructionBase
    {
        public DelayInstruction
        (
            ITimestamp timestamp,
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
        ) : this(DateAndTimeHelper.UnixHelper.CreateDefaultUnixTimestamp(), action, onDestroy, delay)
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
        private readonly ITimestamp _timestamp;
        
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

using System;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public class WaitForTimeSpanInstruction 
        : CoroutineInstructionBase
    {
        public WaitForTimeSpanInstruction(TimeSpan time)
        {
            _time = time;
        }

        private readonly TimeSpan _time;

        private float _secondsElapsed = 0f;
        
        public override bool IsFinished(float deltaTime)
        {
            _secondsElapsed += deltaTime;

            var result = _secondsElapsed >= _time.TotalSeconds;
            return result;
        }
    }
}
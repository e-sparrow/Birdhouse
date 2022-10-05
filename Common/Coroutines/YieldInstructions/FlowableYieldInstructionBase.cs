using Birdhouse.Abstractions.Interfaces;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public abstract class FlowableYieldInstructionBase : YieldInstructionBase, IFlowable
    {
        protected FlowableYieldInstructionBase(float duration)
        {
            _duration = duration;
        }

        private readonly float _duration;

        protected abstract float GetProgress();
        
        protected override bool IsFinished()
        {
            var progress = GetProgress() * Speed;

            var result = progress >= _duration;
            return result;
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        public float Speed
        {
            get;
            private set;
        }
    }
}
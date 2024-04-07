using Birdhouse.Abstractions.Interfaces;
using Birdhouse.Abstractions.Misc;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public abstract class FlowableYieldInstructionBase 
        : YieldInstructionBase, IFlowable
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

        public float Speed
        {
            get;
            set;
        }
    }
}
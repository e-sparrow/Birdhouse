using UnityEngine;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public abstract class YieldInstructionBase : CustomYieldInstruction
    {
        public override bool keepWaiting => !IsFinished();

        protected abstract bool IsFinished();
    }
}
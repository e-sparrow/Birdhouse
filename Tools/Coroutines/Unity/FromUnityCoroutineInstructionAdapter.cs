using UnityEngine;

namespace Birdhouse.Tools.Coroutines.Unity
{
    public sealed class FromUnityCoroutineInstructionAdapter
        : CoroutineInstructionBase
    {
        public FromUnityCoroutineInstructionAdapter(CustomYieldInstruction inner)
        {
            _inner = inner;
        }

        private readonly CustomYieldInstruction _inner;
        
        public override bool IsFinished(float deltaTime)
        {
            var result = !_inner.keepWaiting;
            return result;
        }
    }
}
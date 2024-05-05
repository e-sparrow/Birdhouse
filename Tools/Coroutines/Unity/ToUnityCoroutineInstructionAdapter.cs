using Birdhouse.Tools.Coroutines.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Coroutines.Unity
{
    public sealed class ToUnityCoroutineInstructionAdapter
        : CustomYieldInstruction
    {
        public ToUnityCoroutineInstructionAdapter(ICoroutineInstruction inner)
        {
            _inner = inner;
        }

        private readonly ICoroutineInstruction _inner;

        public override bool keepWaiting => !_inner.IsFinished(Time.deltaTime);
    }
}
using System;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitWhileInstruction 
        : CoroutineInstructionBase
    {
        public WaitWhileInstruction(Func<bool> func)
        {
            _func = func;
        }
        
        private readonly Func<bool> _func;
        
        public override bool IsFinished(float deltaTime)
        {
            var result = _func.Invoke();
            return !result;
        }
    }
}
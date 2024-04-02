using Birdhouse.Tools.Coroutines.Instructions;
using Birdhouse.Tools.Coroutines.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Coroutines.Unity
{
    public readonly struct UnityInstructionWrapper
        : IInstructionWrapper
    {
        public bool TryWrap(object instruction, out ICoroutineInstruction result)
        {
            result = null;
            
            if (instruction is CustomYieldInstruction customYieldInstruction)
            {
                result = new WaitWhileInstruction(() => customYieldInstruction.keepWaiting);
                return true;
            }
            
            if (instruction is null)
            {
                result = new WaitForFrameInstruction();
                return true;
            }

            return false;
        }
    }
}
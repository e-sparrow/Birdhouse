using System.Collections.Generic;
using System.Linq;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitForAnyInstruction 
        : CoroutineInstructionBase
    {
        public WaitForAnyInstruction(params ICoroutineInstruction[] instructions) 
            : this(instructions.AsEnumerable())
        {
            
        }
        
        public WaitForAnyInstruction(IEnumerable<ICoroutineInstruction> instructions)
        {
            _instructions = instructions;
        }

        private readonly IEnumerable<ICoroutineInstruction> _instructions;
        
        public override bool IsFinished(float deltaTime)
        {
            foreach (var instruction in _instructions)
            {
                var isFinished = instruction.IsFinished(deltaTime);
                if (isFinished)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitForAllInstruction 
        : CoroutineInstructionBase
    {
        public WaitForAllInstruction(params ICoroutineInstruction[] instructions) 
            : this(instructions.AsEnumerable())
        {
            
        }
        
        public WaitForAllInstruction(IEnumerable<ICoroutineInstruction> instructions)
        {
            _instructions = instructions;
        }

        private readonly IEnumerable<ICoroutineInstruction> _instructions;

        public override bool IsFinished(float deltaTime)
        {
            var isFinished = true;
            foreach (var instruction in _instructions)
            {
                var isInstructionFinished = instruction.IsFinished(deltaTime);
                if (!isInstructionFinished)
                {
                    isFinished = false;
                }
            }

            return isFinished;
        }
    }
}
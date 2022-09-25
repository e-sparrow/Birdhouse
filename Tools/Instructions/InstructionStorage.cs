using System.Collections.Generic;
using Birdhouse.Tools.Instructions.Interfaces;

namespace Birdhouse.Tools.Instructions
{
    public readonly struct InstructionStorage : IInstructionStorage
    {
        public InstructionStorage(IList<IInstruction> instructions, IList<IInstructionQueue> instructionQueues)
        {
            Instructions = instructions;
            InstructionQueues = instructionQueues;
        }

        public IList<IInstruction> Instructions
        {
            get;
        }

        public IList<IInstructionQueue> InstructionQueues
        {
            get;
        }
    }
}
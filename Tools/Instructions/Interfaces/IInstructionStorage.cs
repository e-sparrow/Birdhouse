using System.Collections.Generic;

namespace Birdhouse.Tools.Instructions.Interfaces
{
    public interface IInstructionStorage
    {
        IList<IInstruction> Instructions
        {
            get;
        }

        IList<IInstructionQueue> InstructionQueues
        {
            get;
        }
    }
}
using System.Collections.Generic;

namespace ESparrow.Utils.Instructions.Interfaces
{
    public interface IInstructionStorage
    {
        List<IInstruction> Instructions
        {
            get;
        }

        List<IInstructionQueue> InstructionQueues
        {
            get;
        }
    }
}
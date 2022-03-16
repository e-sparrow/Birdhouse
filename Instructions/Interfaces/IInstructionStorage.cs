using System.Collections.Generic;

namespace ESparrow.Utils.Instructions.Interfaces
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
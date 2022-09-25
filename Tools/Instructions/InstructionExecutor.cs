using Birdhouse.Tools.Instructions.Interfaces;

namespace Birdhouse.Tools.Instructions
{
    public class InstructionExecutor : InstructionExecutorBase 
    {
        protected override bool CheckInstruction(IInstruction instruction)
        {
            bool executed = instruction.TryExecute();
            return executed;
        }

        protected override bool CheckInstructionQueue(IInstructionQueue queue, out bool last)
        {
            last = false;
            
            bool executed = queue.TryExecuteLast(out bool isLast);
            if (isLast)
            {
                last = true;
            }

            return executed;
        }
    }
}
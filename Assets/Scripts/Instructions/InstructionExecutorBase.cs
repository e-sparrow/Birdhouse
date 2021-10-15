using System.Collections.Generic;
using ESparrow.Utils.Instructions.Interfaces;

namespace ESparrow.Utils.Instructions
{
    public abstract class InstructionExecutorBase : IInstructionExecutor
    {
        public void Check(IInstructionStorage storage)
        {
            var incomingInstructions = new List<IInstruction>(storage.Instructions);
            foreach (var instruction in incomingInstructions)
            {
                if (CheckInstruction(instruction))
                {
                    if (!instruction.SelfDestroy) continue;
                    instruction.OnDestroy.Invoke();;
                }
            }

            var incomingQueues = new List<IInstructionQueue>(storage.InstructionQueues);
            foreach (var queue in incomingQueues)
            {
                if (CheckInstructionQueue(queue, out bool last))
                {
                    if (last)
                    {
                        storage.InstructionQueues.Remove(queue);
                    }
                }
            }
        }
        
        /// <summary>
        /// Checks instruction and executes it if it's valid.
        /// </summary>
        /// <param name="instruction">Instruction to check</param>
        /// <returns>True if instruction is executed and false otherwise</returns>
        protected abstract bool CheckInstruction(IInstruction instruction);
        /// <summary>
        /// Checks last instruction in the queue and executes it if it's valid.
        /// </summary>
        /// <param name="queue">Queue to check</param>
        /// <param name="last">Is this instruction was last in the queue</param>
        /// <returns>True if instruction is executed and false otherwise</returns>
        protected abstract bool CheckInstructionQueue(IInstructionQueue queue, out bool last);
    }
}

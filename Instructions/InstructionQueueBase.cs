using ESparrow.Utils.Instructions.Interfaces;

namespace ESparrow.Utils.Instructions
{
    public abstract class InstructionQueueBase : IInstructionQueue
    {
        public abstract bool TryExecuteLast(out bool last);

        public abstract void Add(IInstruction instruction);

        public abstract void Skip();
        public abstract void Reverse();
    }
}
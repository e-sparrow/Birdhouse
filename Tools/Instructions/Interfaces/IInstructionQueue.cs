namespace Birdhouse.Tools.Instructions.Interfaces
{
    public interface IInstructionQueue
    {
        /// <summary>
        /// Tries to execute the last instruction of queue.
        /// </summary>
        /// <param name="last">Is executed instruction was last in the queue</param>
        /// <returns>True if instruction was executed and false otherwise</returns>
        bool TryExecuteLast(out bool last);
        
        /// <summary>
        /// Adds the instruction to the queue.
        /// </summary>
        /// <param name="instruction">Instruction to add</param>
        void Add(IInstruction instruction);
        
        /// <summary>
        /// Skips the specified count of instructions.
        /// </summary>
        void Skip();
        /// <summary>
        /// Reverses instructions in the queue.
        /// </summary>
        void Reverse();
    }
}

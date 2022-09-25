namespace Birdhouse.Tools.Instructions.Interfaces
{
    public interface IInstructionExecutor
    {
        /// <summary>
        /// Checks all the instructions and queues in the storage.
        /// </summary>
        void Check(IInstructionStorage storage);
    }
}   

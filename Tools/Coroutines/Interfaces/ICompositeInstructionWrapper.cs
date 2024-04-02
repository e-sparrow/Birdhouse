namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface ICompositeInstructionWrapper
        : IInstructionWrapper
    {
        ICompositeInstructionWrapper Append(IInstructionWrapper other);
    }
}
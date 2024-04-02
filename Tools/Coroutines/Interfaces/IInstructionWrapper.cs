namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface IInstructionWrapper
    {
        bool TryWrap(object target, out ICoroutineInstruction result);
    }
}
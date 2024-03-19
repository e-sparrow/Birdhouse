using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public abstract class CoroutineInstructionBase
        : ICoroutineInstruction
    {
        public abstract bool IsFinished(float deltaTime);
    }
}
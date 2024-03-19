namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface ICoroutineInstruction
    {
        bool IsFinished(float deltaTime);
    }
}
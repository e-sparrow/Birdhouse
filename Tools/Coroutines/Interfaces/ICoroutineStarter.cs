namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface ICoroutineStarter<in TCoroutine>
    {
        void Start(TCoroutine coroutine);
    }
}
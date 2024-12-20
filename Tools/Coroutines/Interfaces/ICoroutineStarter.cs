namespace Birdhouse.Tools.Coroutines.Interfaces
{
    public interface ICoroutineStarter<in TCoroutine, out TToken>
    {
        TToken Start(TCoroutine coroutine);
    }
    
    public interface ICoroutineStarter<in TCoroutine>
    {
        void Start(TCoroutine coroutine);
    }
}
namespace Birdhouse.Features.Idle.Interfaces
{
    public interface IRealtimeIdleManager 
    {
        void Register(IIdleController controller);
        void Unregister(IIdleController controller);

        void Check();
    }
}

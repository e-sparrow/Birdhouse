using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Idle.Interfaces
{
    public interface IRealtimeIdleManager : IRegistry<IIdleController>
    {
        void Check();
    }
}

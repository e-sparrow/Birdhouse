using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Features.Idle.Interfaces
{
    public interface IRealtimeIdleManager
        : IRegistry<IIdleController>
    {
        void Check();
    }
}

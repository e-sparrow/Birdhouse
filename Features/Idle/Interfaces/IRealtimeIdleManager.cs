using System;

namespace Birdhouse.Features.Idle.Interfaces
{
    public interface IRealtimeIdleManager 
    {
        IDisposable Register(IIdleController controller);

        void Check();
    }
}

using System;
using ESparrow.Utils.Tools.Offline.Interfaces;

namespace ESparrow.Utils.Mechanics.Idle.Interfaces
{
    public interface IRealtimeIdleManager 
    {
        void Register(IIdleController controller);
        void Unregister(IIdleController controller);
    }
}

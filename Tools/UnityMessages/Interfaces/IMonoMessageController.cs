using System;

namespace Birdhouse.Tools.UnityMessages.Interfaces
{
    public interface IMonoMessageController
    {
        event Action OnAwake;
        event Action OnStart;
        event Action OnUpdate;
        event Action OnFixedUpdate;
        event Action OnLateUpdate;

        event Action OnApplicationQuitCalled;
        
        event Action<bool> OnApplicationFocusCalled;
        event Action<bool> OnApplicationPauseCalled;
    }
}
using System;

namespace ESparrow.Utils.Tools.UnityMessages
{
    public interface IUnityMessageController
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
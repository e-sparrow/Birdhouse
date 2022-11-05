using System;
using Birdhouse.Common.Singleton.Mono;
using Birdhouse.Tools.UnityMessages.Interfaces;

namespace Birdhouse.Tools.UnityMessages
{
    public sealed class MonoMessageController : MonoSingleton<MonoMessageController>, IMonoMessageController
    {
        public event Action OnAwake = () => { };
        public event Action OnStart = () => { };
        public event Action OnUpdate = () => { };
        public event Action OnFixedUpdate = () => { };
        public event Action OnLateUpdate = () => { };
        
        public event Action OnApplicationQuitCalled = () => { };
        
        public event Action<bool> OnApplicationFocusCalled = _ => { };
        public event Action<bool> OnApplicationPauseCalled = _ => { };
        
        private void Awake() => OnAwake.Invoke();
        private void Start() => OnStart.Invoke();
        private void Update() => OnUpdate.Invoke();
        private void FixedUpdate() => OnFixedUpdate.Invoke();
        private void LateUpdate() => OnLateUpdate.Invoke();

        private void OnApplicationQuit() => OnApplicationQuitCalled.Invoke();
        private void OnApplicationFocus(bool focus) => OnApplicationFocusCalled.Invoke(focus);
        private void OnApplicationPause(bool pause) => OnApplicationPauseCalled.Invoke(pause);
    }
}

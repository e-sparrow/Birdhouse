using System;
using ESparrow.Utils.Patterns.Singleton;

namespace ESparrow.Utils.Managers
{
    public class UnityMessagesManager : UnitySingleton<UnityMessagesManager>
    {
        public event Action AwakeHandler;
        public event Action StartHandler;
        public event Action UpdateHandler;
        public event Action FixedUpdateHandler;
        public event Action LateUpdateHandler;

        public event Action OnApplicationQuitHandler;
        public event Action<bool> OnApplicationFocusHandler;
        public event Action<bool> OnApplicationPauseHandler;

        private void Awake() => AwakeHandler?.Invoke();
        private void Start() => StartHandler?.Invoke();
        private void Update() => UpdateHandler?.Invoke();
        private void FixedUpdate() => FixedUpdateHandler?.Invoke();
        private void LateUpdate() => LateUpdateHandler?.Invoke();

        private void OnApplicationQuit() => OnApplicationQuitHandler?.Invoke();
        private void OnApplicationFocus(bool focus) => OnApplicationFocusHandler?.Invoke(focus);
        private void OnApplicationPause(bool pause) => OnApplicationPauseHandler?.Invoke(pause);
    }
}

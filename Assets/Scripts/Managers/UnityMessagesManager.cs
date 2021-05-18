using System;
using ESparrow.Utils.Patterns.Singleton;

namespace ESparrow.Utils.Managers
{
    public class UnityMessagesManager : UnitySingleton<UnityMessagesManager>
    {
        public static event Action AwakeHandler;
        public static event Action StartHandler;
        public static event Action UpdateHandler;
        public static event Action FixedUpdateHandler;
        public static event Action LateUpdateHandler;

        public static event Action OnApplicationQuitHandler;
        public static event Action<bool> OnApplicationFocusHandler;
        public static event Action<bool> OnApplicationPauseHandler;

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

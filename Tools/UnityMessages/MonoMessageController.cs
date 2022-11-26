using System;
using Birdhouse.Common.Singleton.Mono;
using Birdhouse.Tools.UnityMessages.Enums;
using Birdhouse.Tools.UnityMessages.Interfaces;

namespace Birdhouse.Tools.UnityMessages
{
    public sealed class MonoMessageController : MonoSingleton<MonoMessageController>, IMonoMessageController
    {
        public event Action<EMonoMessage> OnMessageCalled = _ => { };
        public event Action<EMonoEntryMessage> OnEntryMessageCalled = _ => { } ;

        public event Action<bool> OnApplicationFocusCalled = _ => { };
        public event Action<bool> OnApplicationPauseCalled = _ => { };

        private void Awake()
        {
            OnMessageCalled.Invoke(EMonoMessage.Awake);
            OnEntryMessageCalled(EMonoEntryMessage.Awake);
        }

        private void Start()
        {
            OnMessageCalled.Invoke(EMonoMessage.Start);
            OnEntryMessageCalled.Invoke(EMonoEntryMessage.Start);
        }
        
        private void Update()
        {
            OnMessageCalled.Invoke(EMonoMessage.Update);
        }
        
        private void FixedUpdate()
        {
            OnMessageCalled.Invoke(EMonoMessage.FixedUpdate);
        }
        
        private void LateUpdate()
        {
            OnMessageCalled.Invoke(EMonoMessage.LateUpdate);
        }

        private void OnApplicationQuit()
        {
            OnMessageCalled.Invoke(EMonoMessage.ApplicationQuit);
        }
        
        private void OnApplicationFocus(bool focus) => OnApplicationFocusCalled.Invoke(focus);
        private void OnApplicationPause(bool pause) => OnApplicationPauseCalled.Invoke(pause);
    }
}

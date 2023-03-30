using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Common.Singleton.Mono;
using Birdhouse.Tools.UnityMessages.Enums;
using Birdhouse.Tools.UnityMessages.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.UnityMessages
{
    [ExecuteAlways]
    public sealed class UnityMessageController : MonoSingleton<UnityMessageController>, IMonoMessageController
    {
        public event Action<EUnityMessage> OnMessageCalled = _ => { };
        public event Action<EUnityEntryMessage> OnEntryMessageCalled = _ => { } ;

        public event Action<bool> OnApplicationFocusCalled = _ => { };
        public event Action<bool> OnApplicationPauseCalled = _ => { };

        public IDisposable RegisterMessage(EUnityMessage message, Action callback)
        {
            OnMessageCalled += Call;

            var disposable = new CallbackDisposable(Dispose);
            return disposable;

            void Call(EUnityMessage type)
            {
                if (type != message) return; 
                
                callback.Invoke();
            }

            void Dispose()
            {
                OnMessageCalled -= Call;
            }
        }
        
        public IDisposable RegisterEntryMessage(EUnityEntryMessage message, Action callback)
        {
            OnEntryMessageCalled += Call;

            var disposable = new CallbackDisposable(Dispose);
            return disposable;

            void Call(EUnityEntryMessage type)
            {
                if (type != message) return; 
                
                callback.Invoke();
            }

            void Dispose()
            {
                OnEntryMessageCalled -= Call;
            }
        }

        private void Awake()
        {
            OnMessageCalled.Invoke(EUnityMessage.Awake);
            OnEntryMessageCalled(EUnityEntryMessage.Awake);
        }

        private void Start()
        {
            OnMessageCalled.Invoke(EUnityMessage.Start);
            OnEntryMessageCalled.Invoke(EUnityEntryMessage.Start);
        }
        
        private void Update()
        {
            OnMessageCalled.Invoke(EUnityMessage.Update);
        }
        
        private void FixedUpdate()
        {
            OnMessageCalled.Invoke(EUnityMessage.FixedUpdate);
        }
        
        private void LateUpdate()
        {
            OnMessageCalled.Invoke(EUnityMessage.LateUpdate);
        }

        private void OnApplicationQuit()
        {
            OnMessageCalled.Invoke(EUnityMessage.ApplicationQuit);
        }
        
        private void OnApplicationFocus(bool focus) => OnApplicationFocusCalled.Invoke(focus);
        private void OnApplicationPause(bool pause) => OnApplicationPauseCalled.Invoke(pause);
    }
}

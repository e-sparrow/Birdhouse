using System;
using UnityEngine.LowLevel;

namespace Birdhouse.Tools.UnityMessages
{
    internal class PlayerLoopSystemSubscription<T> : IDisposable
    {
        public PlayerLoopSystemSubscription(Action callback)
        {
            _callback = callback;
            Subscribe();
        }
        
        private readonly Action _callback;

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Invoke()
        {
            _callback.Invoke();
        }

        private void Subscribe()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find<T>();
            system.updateDelegate += Invoke;
            PlayerLoop.SetPlayerLoop(loop);
        }

        private void Unsubscribe()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find<T>();
            system.updateDelegate -= Invoke;
            PlayerLoop.SetPlayerLoop(loop);
        }
    }
}
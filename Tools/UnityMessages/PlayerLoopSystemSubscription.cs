using System;
using UnityEngine.LowLevel;

namespace Birdhouse.Tools.UnityMessages
{
    public class PlayerLoopSystemSubscription
        : IDisposable
    {
        public PlayerLoopSystemSubscription(Type type, Action action)
        {
            _type = type;
            _action = action;
            
            Subscribe();
        }

        private readonly Type _type;
        private readonly Action _action;

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Invoke()
        {
            _action.Invoke();
        }

        private void Subscribe()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find(_type);
            system.updateDelegate += Invoke;
            PlayerLoop.SetPlayerLoop(loop);
        }

        private void Unsubscribe()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find(_type);
            system.updateDelegate -= Invoke;
            PlayerLoop.SetPlayerLoop(loop);
        }
    }

    public class PlayerLoopSystemSubscription<T>
        : IDisposable
    {
        public PlayerLoopSystemSubscription(Action action)
        {
            _inner = new PlayerLoopSystemSubscription(typeof(T), action);
        }

        private readonly PlayerLoopSystemSubscription _inner;

        public void Dispose()
        {
            _inner.Dispose();
        }
    }
}
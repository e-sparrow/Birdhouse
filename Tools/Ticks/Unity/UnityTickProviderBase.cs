using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;
using Birdhouse.Tools.UnityMessages;
using UnityEngine.LowLevel;

namespace Birdhouse.Tools.Ticks.Unity
{
    public abstract class UnityTickProviderBase 
        : ITickProvider
    {
        public UnityTickProviderBase(Type subsystemType)
        {
            _ticks = new RegistryEnumerable<Action<float>, IDisposable>(CreateTickSubscription);
            _subsystemType = subsystemType;
        }

        private readonly Type _subsystemType;

        private readonly IRegistryEnumerable<Action<float>, IDisposable> _ticks;

        private IDisposable CreateTickSubscription(Action<float> action, ICollection<Action<float>> destination)
        {
            var result = action
                .AddAsDisposableTo(destination)
                .OnDispose(CheckRegistry);

            return result;
        }

        private void CheckRegistry()
        {
            var isEmpty = !_ticks.Any();
            if (isEmpty)
            {
                Unsubscribe();
            }
        }

        protected abstract float GetDeltaTime();

        public IDisposable RegisterTick(Action<float> tick)
        {
            var isEmpty = _ticks.Any();
            var result = _ticks.Register(tick);
            
            if (isEmpty)
            {
                Subscribe();
            }

            return result;
        }

        private void Invoke()
        {
            var deltaTime = GetDeltaTime();
            foreach (var tick in _ticks)
            {
                tick.Invoke(deltaTime);
            }
        }

        private void Subscribe()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find(_subsystemType);
            system.updateDelegate += Invoke;
            PlayerLoop.SetPlayerLoop(loop);
        }

        private void Unsubscribe()
        {
            var loop = PlayerLoop.GetCurrentPlayerLoop();
            ref var system = ref loop.Find(_subsystemType);
            system.updateDelegate -= Invoke;
            PlayerLoop.SetPlayerLoop(loop);
        }
    }
}
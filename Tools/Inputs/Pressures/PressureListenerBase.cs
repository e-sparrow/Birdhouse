using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Disposables.Interfaces;
using Birdhouse.Abstractions.Observables.Interfaces;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Tense.Providers.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public abstract class PressureListenerBase<TKey, TTime> 
        : IPressureListener<TKey, TTime>, IDisposable
    {
        protected PressureListenerBase
        (
            ITenseProvider<TTime> tenseProvider, 
            IPressureStateProvider<TKey> stateProvider, 
            ITickProvider tickProvider
        )
        {
            _tenseProvider = tenseProvider;
            _stateProvider = stateProvider;
            _tickToken = tickProvider.RegisterTick(Update);
        }

        private readonly ITenseProvider<TTime> _tenseProvider;
        private readonly IPressureStateProvider<TKey> _stateProvider;
        private readonly IDisposable _tickToken;

        private readonly IDictionary<TKey, PressureStateListener> _listeners
            = new Dictionary<TKey, PressureStateListener>();

        public IObservableDisposableValue<PressureStateChange<TTime>> Listen(TKey key)
        {
            var hasValue = _listeners.TryGetValue(key, out var value);
            if (!hasValue)
            {
                value = new PressureStateListener();
                var token = _listeners.AddAsDisposable(key, value);
                value.Replace(token);
            }
            
            value.Subscribe();
            return value;
        }

        public void Dispose()
        {
            _tickToken.Dispose();   
        }

        private void Update(float deltaTime)
        {
            foreach (var (key, value) in _listeners)
            {
                var state = _stateProvider.GetPressureState(key);
                
                var isChanged = state != value.Value.State;
                if (isChanged)
                {
                    var time = _tenseProvider.Now();
                    
                    var newState = new PressureStateChange<TTime>(state, time);
                    value.SetValue(newState);
                }
            }
        }

        // TODO: Вынести в отдельную сущность с методом расширения Disposable, вызывающий Dispose при определённом
        // (конфигурируемом и изменяемом) количестве вызовов, как здесь
        private class PressureStateListener
            : IObservableDisposableValue<PressureStateChange<TTime>>, IReplaceableDisposable
        {
            public event Action<PressureStateChange<TTime>> OnValueChanged = _ => { };

            private IDisposable _token;
            private int _count = 0;

            public PressureStateChange<TTime> Value
            {
                get;
                private set;
            }

            public void Dispose()
            {
                _count--;

                var isFinal = _count <= 0;
                if (isFinal)
                {
                    _token.Dispose();
                }
            }

            public void Replace(IDisposable other)
            {
                _token = other;
            }

            public void Subscribe()
            {
                _count++;
            }

            public void SetValue(PressureStateChange<TTime> value)
            {
                Value = value;
            }
        }
    }
}
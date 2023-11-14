using System;
using Birdhouse.Abstractions.Disposables.Interfaces;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Inputs.AnyKey.Interfaces;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public class UnityAnyKeyListener 
        : IAnyKeyListener<KeyCode>
    {
        public UnityAnyKeyListener(IPressureStateProvider<KeyCode> pressureStateProvider, ITickProvider tickProvider)
        {
            _pressureStateProvider = pressureStateProvider;
            _tickToken = tickProvider.RegisterTick(Update);
        }

        private readonly IPressureStateProvider<KeyCode> _pressureStateProvider;
        private readonly IDisposable _tickToken;

        private readonly IRegistryDictionary<EPressureState, UnityAnyKeyPressureListener> _listeners
            = new RegistryDictionary<EPressureState, UnityAnyKeyPressureListener>();

        public IAnyKeyPressureListener<KeyCode> RegisterListener(EPressureState state)
        {
            var value = new UnityAnyKeyPressureListener(state);
            var token = _listeners.Register(state, value);
            
            value.Replace(token);
            return value;
        }

        public void Dispose()
        {
            _tickToken.Dispose();
            _listeners.Dispose();
        }

        private void Update(float deltaTime)
        {
            var currentEvent = Event.current;
            if (currentEvent.isKey)
            {
                var keyCode = currentEvent.keyCode;
                var state = _pressureStateProvider.GetPressureState(keyCode);
                
                var hasValue = _listeners.TryGetValue(state, out var value);
                if (hasValue)
                {
                    value.Perform(keyCode);
                }
            }
        }

        private class UnityAnyKeyPressureListener
            : IAnyKeyPressureListener<KeyCode>, IReplaceableDisposable
        {
            public UnityAnyKeyPressureListener(EPressureState targetState)
            {
                _targetState = targetState;
            }

            public event Action<KeyCode> OnPressurePerformed = _ => { };

            private IDisposable _token;
            
            private readonly EPressureState _targetState;
            
            public void Dispose()
            {
                _token.Dispose();
            }

            public void Replace(IDisposable other)
            {
                _token = other;
            }

            public void Perform(KeyCode value)
            {
                OnPressurePerformed.Invoke(value);
            }
        }
    }
}
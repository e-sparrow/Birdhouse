using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Abstractions.Interfaces;
using Birdhouse.Abstractions.Observables.Interfaces;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Inputs.Remapping.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping
{
    public abstract class RemapperBase<TKey, TValue> 
        : IRemapper<TKey, TValue>
    {
        private readonly IRegistryEnumerable<TValue> _exceptions = new RegistryEnumerable<TValue>();
        private readonly IDictionary<TKey, ObservableValue> _observables = new Dictionary<TKey, ObservableValue>();

        protected abstract IDictionary<TKey, TValue> GetInitialDictionary();

        public void Initialize()
        {
            var isNotEmpty = _observables.Any();
            if (isNotEmpty)
            {
                var message = $"Remapper of type \"{GetType()}\" is already initialized!";
                
                var exception = new AlreadyInitializedException(this, message);
                throw exception;
            }

            var initial = GetInitialDictionary()
                .ToDictionary(pair => pair.Key, pair => new ObservableValue(pair.Value));
            
            _observables.AddRange(initial);
        }

        public IDisposable RegisterException(TValue value)
        {
            var result = _exceptions.Register(value);
            return result;
        }

        public IObservableValue<TValue> GetValue(TKey key)
        {
            var result = _observables[key];
            return result;
        }

        public bool TrySetValue(TKey key, TValue value)
        {
            var isException = _exceptions.Contains(value);
            if (isException)
            {
                return false;
            }

            var isCollision = _observables.Any(item => item.Value.Value.Equals(value));
            if (isCollision)
            {
                return false;
            }

            _observables[key].SetValue(value);
            return true;
        }

        private sealed class ObservableValue
            : IObservableValue<TValue>
        {
            public ObservableValue(TValue value)
            {
                Value = value;
            }
            
            public event Action<TValue> OnValueChanged = _ => { };

            public TValue Value
            {
                get;
                private set;
            }

            public void SetValue(TValue value)
            {
                Value = value;
                OnValueChanged.Invoke(value);
            }
        }
    }
}

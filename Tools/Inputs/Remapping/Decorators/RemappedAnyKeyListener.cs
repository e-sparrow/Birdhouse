using System;
using Birdhouse.Tools.Inputs.AnyKey.Interfaces;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Remapping.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping.Decorators
{
    public class RemappedAnyKeyListener<TFrom, TTo> 
        : IAnyKeyListener<TTo>
    {
        public RemappedAnyKeyListener(IRemapper<TTo, TFrom> remapper, IAnyKeyListener<TFrom> listener)
        {
            _remapper = remapper;
            _listener = listener;
        }

        private readonly IAnyKeyListener<TFrom> _listener;
        private readonly IRemapper<TTo, TFrom> _remapper;

        public IAnyKeyPressureListener<TTo> RegisterListener(EPressureState state)
        {
            var inner = _listener.RegisterListener(state);
            
            var result = new RemappedAnyKeyPressureListener(inner, _remapper);
            return result;
        }

        public void Dispose()
        {
            _listener.Dispose();
            _remapper.Dispose();
        }

        private class RemappedAnyKeyPressureListener
            : IAnyKeyPressureListener<TTo>
        {
            public RemappedAnyKeyPressureListener(IAnyKeyPressureListener<TFrom> inner, IRemapper<TTo, TFrom> remapper)
            {
                _inner = inner;
                _remapper = remapper;
                
                _inner.OnPressurePerformed += CheckAndPerform;
            }

            private readonly IAnyKeyPressureListener<TFrom> _inner;
            private readonly IRemapper<TTo, TFrom> _remapper;

            public event Action<TTo> OnPressurePerformed = _ => { };
            
            public void Dispose()
            {
                _inner.OnPressurePerformed -= CheckAndPerform;
                _inner.Dispose();
            }

            private void CheckAndPerform(TFrom value)
            {
                throw new NotImplementedException();
                
                /*
                var hasValue = _remapper.TryGetValue(value, out var result);
                if (hasValue)
                {
                    
                }
                */
            }
        }
    }
}
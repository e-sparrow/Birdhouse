using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Abstractions.Observables.Interfaces;
using Birdhouse.Features.Decisions.Interfaces;
using Birdhouse.Tools.Inputs.Pressures;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Decisions
{
    public class PressureDecider<TKey, TTime>
        : IDecider<TKey>
    {
        public PressureDecider(IEnumerable<TKey> keys, IPressureListener<TKey, TTime> listener)
        {
            Action onDispose = () => { };

            _token = new CallbackDisposable(onDispose);
            foreach (var key in keys)
            {
                var observer = listener.Listen(key);
                observer.OnValueChanged += Decide;

                onDispose += () => observer.OnValueChanged -= Decide;
                
                _token = _token.Append(observer);

                void Decide(PressureStateChange<TTime> stateChange)
                {
                    if (stateChange.State is EPressureState.Untouched)
                    {
                        return;
                    }
                    
                    OnDecide.Invoke(key);
                    _token.Dispose();
                }
            }
        }
        
        public PressureDecider(IPressureListener<TKey, TTime> listener, params TKey[] keys) 
            : this(keys, listener)
        {
            
        }

        public event Action<TKey> OnDecide = _ => { };

        private readonly IDisposable _token;

        public void Dispose()
        {
            _token.Dispose();
        }
    }
}
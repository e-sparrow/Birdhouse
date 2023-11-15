using System;
using Birdhouse.Abstractions.Interfaces;
using Birdhouse.Abstractions.Observables.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping.Interfaces
{
    public interface IRemapper<in TKey, TValue> 
        : IInitializable, IDisposable
    {
        IDisposable RegisterException(TValue value);
        
        bool TryGetValue(TKey key, out IObservableValue<TValue> value);
        bool TrySetValue(TKey key, TValue value);
    }
}
using System;
using Birdhouse.Abstractions.Interfaces;
using Birdhouse.Abstractions.Observables.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping.Interfaces
{
    public interface IRemapper<in TKey, TValue> 
        : IInitializable
    {
        IDisposable RegisterException(TValue value);
        
        IObservableValue<TValue> GetValue(TKey key);
        bool TrySetValue(TKey key, TValue value);
    }
}
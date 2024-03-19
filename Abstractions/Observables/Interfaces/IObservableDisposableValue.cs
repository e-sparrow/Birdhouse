using System;

namespace Birdhouse.Abstractions.Observables.Interfaces
{
    public interface IObservableDisposableValue<out TValue>
        : IObservableValue<TValue>, IDisposable
    {
        
    }
}
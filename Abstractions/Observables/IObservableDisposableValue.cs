using System;

namespace Birdhouse.Abstractions.Observables
{
    public interface IObservableDisposableValue<out TValue>
        : IObservableValue<TValue>, IDisposable
    {
        
    }
}
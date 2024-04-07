using System;

namespace Birdhouse.Abstractions.Observables
{
    public interface IObservableDisposable 
        : IDisposable
    {
        event Action OnDispose;
    }
}
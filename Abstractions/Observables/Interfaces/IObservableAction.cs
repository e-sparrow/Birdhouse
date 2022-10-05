using System;

namespace Birdhouse.Abstractions.Observables.Interfaces
{
    public interface IObservableAction
    {
        event Action OnInvoke;
        
        void Invoke();
    }
}
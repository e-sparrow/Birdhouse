using System;

namespace Birdhouse.Abstractions.Observables
{
    public interface IObservableAction
    {
        event Action OnInvoke;
        
        void Invoke();
    }
}
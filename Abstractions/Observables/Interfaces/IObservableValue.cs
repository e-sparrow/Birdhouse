using System;

namespace Birdhouse.Abstractions.Observables.Interfaces
{
    public interface IObservableValue<out TValue>
    {
        event Action<TValue> OnValueChanged;

        TValue Value
        {
            get;
        }
    }
}
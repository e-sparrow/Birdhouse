using System;

namespace Birdhouse.Abstractions.Observables
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
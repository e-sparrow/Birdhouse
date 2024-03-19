using Birdhouse.Abstractions.Observables.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures.Interfaces
{
    public interface IPressureListener<in TKey, TTime>
    {
        IObservableDisposableValue<PressureStateChange<TTime>> Listen(TKey key);
    }
}
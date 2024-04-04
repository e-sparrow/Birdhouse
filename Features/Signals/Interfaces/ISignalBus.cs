using System;

namespace Birdhouse.Features.Signals.Interfaces
{
    public interface ISignalBus<in TBase>
    {
        IDisposable Subscribe<T>(Action<T> action) 
            where T : TBase;

        void Fire<T>()
            where T : TBase;
    }
}
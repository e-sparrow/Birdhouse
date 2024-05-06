using System;

namespace Birdhouse.Tools.Signals.Abstractions
{
    public interface ISignalBus<in TBase>
    {
        public void Fire<T>(T argument)
            where T : TBase;

        public IDisposable Subscribe<T>(Action<T> handler)
            where T : TBase;
    }

    public interface ISignalBus 
        : ISignalBus<object>
    {
        
    }
}
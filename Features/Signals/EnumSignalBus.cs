using System;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Features.Signals.Interfaces;

namespace Birdhouse.Features.Signals
{
    public class EnumSignalBus<TBase>
        : ISignalBus<TBase>
        where TBase : Enum
    {
        public IDisposable Subscribe<T>(Action<T> action) 
            where T : TBase
        {
            throw new NotImplementedException();
        }

        public void Fire<T>() 
            where T : TBase
        {
            throw new NotImplementedException();
        }
    }
}
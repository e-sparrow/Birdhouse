using System;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IRegistry<in TElement, out TToken> : IDisposable
        where TToken : IDisposable
    {
        TToken Register(TElement element);
    }

    public interface IRegistry<in TElement> : IRegistry<TElement, IDisposable>
    {
        
    }
}

using System;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IRegistry<in TElement, out TToken, TOut>
        : IDisposable
        where TToken : IDisposable
    {
        TToken Register(TElement element, out TOut result);
    }
    
    public interface IRegistry<in TElement, out TToken> 
        : IDisposable
        where TToken : IDisposable
    {
        TToken Register(TElement element);
    }

    public interface IRegistry<in TElement> 
        : IRegistry<TElement, IDisposable>
    {
        
    }

    public interface IRegistry 
        : IRegistry<object, IDisposable>
    {
        
    }
}

using System;
using System.Collections.Generic;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IRegistryEnumerable<TElement, out TToken> 
        : IRegistry<TElement, TToken>, IEnumerable<TElement>
        where TToken : IDisposable
    {
        
    }

    public interface IRegistryEnumerable<TElement>
        : IRegistryEnumerable<TElement, IDisposable>
    {
        
    }
}
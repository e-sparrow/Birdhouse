using System;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public abstract class RegistryBase<TElement, TToken> 
        : IRegistry<TElement, TToken>
        where TToken : IDisposable
    {
        public abstract void Dispose();
        
        protected abstract TToken CreateToken(TElement element);

        public TToken Register(TElement element)
        {
            var result = CreateToken(element);
            return result;
        }
    }

    public abstract class RegistryBase<TElement, TToken, TOut>
        : IRegistry<TElement, TToken, TOut>
        where TToken : IDisposable
    {
        protected RegistryBase(IRegistry<TElement, TToken> registry)
        {
            _registry = registry;
        }

        private readonly IRegistry<TElement, TToken> _registry;

        protected abstract TOut GetResult(TElement element);
        
        public TToken Register(TElement element, out TOut result)
        {
            result = GetResult(element);

            var token = _registry.Register(element);
            return token;
        }

        public void Dispose()
        {
            _registry.Dispose();
        }
    }
}
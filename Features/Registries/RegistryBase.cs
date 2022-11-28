using System;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public abstract class RegistryBase<TElement, TToken> : IRegistry<TElement, TToken>
        where TToken : IDisposable
    {
        protected abstract TToken CreateToken(TElement element);

        public TToken Register(TElement element)
        {
            var result = CreateToken(element);
            return result;
        }
    }
}
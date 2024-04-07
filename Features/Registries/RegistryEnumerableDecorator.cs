using System;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public sealed class RegistryDecorator<TElement, TToken>
        : RegistryBase<TElement, TToken> 
        where TToken : IDisposable
    {
        public RegistryDecorator(IRegistry<TElement, TToken> inner)
        {
            _inner = inner;
        }

        private readonly IRegistry<TElement, TToken> _inner;
        
        protected override TToken CreateToken(TElement element)
        {
            throw new NotImplementedException();
        }
        
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
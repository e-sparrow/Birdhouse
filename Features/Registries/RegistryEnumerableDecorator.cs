using System;
using System.Collections.Generic;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    // TODO:
    public sealed class RegistryEnumerableDecorator<TElement, TToken>
        : RegistryEnumerableBase<TElement, TToken> 
        where TToken : IDisposable
    {
        public RegistryEnumerableDecorator(IRegistry<TElement, TToken> inner)
        {
            _inner = inner;
        }

        private readonly IRegistry<TElement, TToken> _inner;

        protected override ICollection<TElement> CreateCollection()
        {
            throw new NotImplementedException();
        }

        protected override TToken CreateToken(TElement value, ICollection<TElement> destination)
        {
            throw new NotImplementedException();
        }

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
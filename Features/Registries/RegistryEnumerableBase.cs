using System;
using System.Collections;
using System.Collections.Generic;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public abstract class RegistryEnumerableBase<T, TToken> 
        : RegistryBase<T, TToken>, IRegistryEnumerable<T, TToken>
        where TToken : IDisposable
    {
        protected RegistryEnumerableBase()
        {
            _collection = new Lazy<ICollection<T>>(CreateCollection);
        }

        private readonly Lazy<ICollection<T>> _collection;

        protected abstract ICollection<T> CreateCollection();
        protected abstract TToken CreateToken(T value, ICollection<T> destination);
        
        public IEnumerator<T> GetEnumerator()
        {
            var result = _collection.Value.GetEnumerator();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var result = GetEnumerator();
            return result;
        }

        protected override TToken CreateToken(T element)
        {
            var result = CreateToken(element, _collection.Value);
            return result;
        }

        public override void Dispose()
        {
            _collection.Value.Clear();
        }
    }
}
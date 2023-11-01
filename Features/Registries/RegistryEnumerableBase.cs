using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public abstract class RegistryEnumerableBase<T, TToken> 
        : RegistryBase<T, TToken>, IRegistryEnumerable<T, TToken>
        where TToken : IDisposable
    {
        private readonly ICollection<T> _collection = new Collection<T>();

        protected abstract TToken CreateToken(T value, ICollection<T> destination);
        
        public IEnumerator<T> GetEnumerator()
        {
            var result = _collection.GetEnumerator();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var result = GetEnumerator();
            return result;
        }

        protected override TToken CreateToken(T element)
        {
            var result = CreateToken(element, _collection);
            return result;
        }

        public override void Dispose()
        {
            _collection.Clear();
        }
    }
}
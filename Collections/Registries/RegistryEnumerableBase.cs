using System;
using System.Collections;
using System.Collections.Generic;
using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Collections.Registries
{
    public abstract class RegistryEnumerableBase<T, TToken> 
        : RegistryBase<T, TToken>, IRegistryEnumerable<T, TToken>
        where TToken : IDisposable
    {
        protected RegistryEnumerableBase() => _collection = new Lazy<ICollection<T>>(CreateCollection);
        

        private readonly Lazy<ICollection<T>> _collection;

        protected abstract ICollection<T> CreateCollection();
        protected abstract TToken CreateToken(T value, ICollection<T> destination);
        
        public IEnumerator<T> GetEnumerator() => _collection.Value.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        protected override TToken CreateToken(T element) => CreateToken(element, _collection.Value);
        public override void Dispose() => _collection.Value.Clear();
    }
}
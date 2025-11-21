using System;
using System.Collections.Generic;
using Birdhouse.Collections.Registries.Abstractions;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Collections.Registries
{
    public class RegistryEnumerable<T> 
        : RegistryEnumerableBase<T, IDisposable>, IRegistryEnumerable<T>
    {
        public RegistryEnumerable(Func<ICollection<T>> collectionCreator = null)
        {
            collectionCreator ??= CreateHashSet;
            _collectionCreator = collectionCreator;
        }
        
        private readonly Func<ICollection<T>> _collectionCreator;

        protected override ICollection<T> CreateCollection() => _collectionCreator.Invoke();
        protected override IDisposable CreateToken(T value, ICollection<T> destination) => value.AddAsDisposableTo(destination);
        private static ICollection<T> CreateHashSet() => new HashSet<T>();
    }

    public class RegistryEnumerable<T, TToken>
        : RegistryEnumerableBase<T, TToken>
        where TToken : IDisposable
    {
        public RegistryEnumerable(Func<T, ICollection<T>, TToken> func, Func<ICollection<T>> collectionCreator = null)
        {
            collectionCreator ??= CreateHashSet;
            
            _func = func;
            _collectionCreator = collectionCreator;
        }

        private readonly Func<T, ICollection<T>, TToken> _func;
        private readonly Func<ICollection<T>> _collectionCreator;

        protected override ICollection<T> CreateCollection() => _collectionCreator.Invoke();
        protected override TToken CreateToken(T value, ICollection<T> destination) => _func.Invoke(value, destination);
        private static ICollection<T> CreateHashSet() => new HashSet<T>();
    }
}
using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
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

        protected override ICollection<T> CreateCollection()
        {
            var result = _collectionCreator.Invoke();
            return result;
        }

        protected override IDisposable CreateToken(T value, ICollection<T> destination)
        {
            var result = value.AddAsDisposableTo(destination);
            return result;
        }

        private static ICollection<T> CreateHashSet()
        {
            var result = new HashSet<T>();
            return result;
        }
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

        protected override ICollection<T> CreateCollection()
        {
            var result = _collectionCreator.Invoke();
            return result;
        }

        protected override TToken CreateToken(T value, ICollection<T> destination)
        {
            var result = _func.Invoke(value, destination);
            return result;
        }

        private static ICollection<T> CreateHashSet()
        {
            var result = new HashSet<T>();
            return result;
        }
    }
}
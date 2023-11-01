using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public class RegistryEnumerable<T> 
        : RegistryEnumerableBase<T, IDisposable>, IRegistryEnumerable<T>
    {
        protected override IDisposable CreateToken(T value, ICollection<T> destination)
        {
            var result = value.AddAsDisposableTo(destination);
            return result;
        }
    }

    public class RegistryEnumerable<T, TToken>
        : RegistryEnumerableBase<T, TToken>
        where TToken : IDisposable
    {
        public RegistryEnumerable(Func<T, ICollection<T>, TToken> func)
        {
            _func = func;
        }

        private readonly Func<T, ICollection<T>, TToken> _func;

        protected override TToken CreateToken(T value, ICollection<T> destination)
        {
            var result = _func.Invoke(value, destination);
            return result;
        }
    }
}
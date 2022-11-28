using System;
using System.Collections;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public class RegistryEnumerable<T> : RegistryBase<T, IDisposable>, IRegistryEnumerable<T>
    {
        private readonly IList<T> _list = new List<T>();

        public override void Dispose()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var result = _list.GetEnumerator();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var result = GetEnumerator();
            return result;
        }

        protected override IDisposable CreateToken(T element)
        {
            var result = element.AddAsDisposableTo(_list);
            return result;
        }
    }
}
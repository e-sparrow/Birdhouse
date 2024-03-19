using System;
using System.Collections.Generic;
using Birdhouse.Features.Decisions.Interfaces;

namespace Birdhouse.Features.Decisions
{
    public class RemappedDecider<TFrom, TTo>
        : IDecider<TTo>
    {
        public RemappedDecider(IDecider<TFrom> inner, IDictionary<TFrom, TTo> dictionary)
        {
            _inner = inner;
            _dictionary = dictionary;

            _inner.OnDecide += Decide;

            void Decide(TFrom value)
            {
                var hasValue = _dictionary.TryGetValue(value, out var realValue);
                if (hasValue)
                {
                    OnDecide.Invoke(realValue);
                    return;
                }

                throw new ArgumentException($"Dictionary doesn't contain value {value}");
            }
        }

        public event Action<TTo> OnDecide = _ => { };
        
        private readonly IDecider<TFrom> _inner;
        private readonly IDictionary<TFrom, TTo> _dictionary;

        public void Dispose()
        {
            _inner.Dispose();
            _dictionary.Clear();
        }
    }
}
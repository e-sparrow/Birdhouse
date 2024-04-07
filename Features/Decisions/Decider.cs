using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Decisions.Interfaces;

namespace Birdhouse.Features.Decisions
{
    public class Decider<TOut>
        : IDecider<TOut>
    {
        public Decider(IEnumerable<IDecision<TOut>> values)
        {
            _values = values;
            Subscribe();
        }

        public event Action<TOut> OnDecide = _ => { };

        private readonly IEnumerable<IDecision<TOut>> _values;

        public void Dispose()
        {
            foreach (var value in _values)
            {
                value.Dispose();
            }
        }

        private void Subscribe()
        {
            foreach (var value in _values)
            {
                value.OnDecide += Decide;

                void Decide()
                {
                    OnDecide.Invoke(value.Value);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Birdhouse.Features.Decisions.Interfaces;

namespace Birdhouse.Features.Decisions
{
    public class CompositeDecider<TOut>
        : ICompositeDecider<TOut>
    {
        public event Action<TOut> OnDecide = _ => { };

        private readonly ICollection<IDecider<TOut>> _deciders 
            = new List<IDecider<TOut>>();

        public ICompositeDecider<TOut> Append(IDecider<TOut> decider)
        {
            decider.OnDecide += Decide;
            _deciders.Add(decider);

            return this;
        }

        public void Dispose()
        {
            foreach (var decision in _deciders)
            {
                decision.OnDecide -= Decide;
                decision.Dispose();
            }
            
            _deciders.Clear();
        }

        private void Decide(TOut value)
        {
            OnDecide.Invoke(value);
        }
    }
}
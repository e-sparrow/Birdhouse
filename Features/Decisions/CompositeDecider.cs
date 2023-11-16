using System;
using System.Collections.Generic;
using Birdhouse.Features.Decisions.Interfaces;

namespace Birdhouse.Features.Decisions
{
    public class CompositeDecider<TOut>
        : ICompositeDecider<TOut>
    {
        public event Action<TOut> OnDecide = _ => { };

        private readonly ICollection<IDecider<TOut>> _decisions 
            = new List<IDecider<TOut>>();

        public ICompositeDecider<TOut> Append(IDecider<TOut> decider)
        {
            decider.OnDecide += Decide;
            _decisions.Add(decider);

            return this;
        }

        public void Dispose()
        {
            foreach (var decision in _decisions)
            {
                decision.OnDecide -= Decide;
            }
            
            _decisions.Clear();
        }

        private void Decide(TOut value)
        {
            OnDecide.Invoke(value);
        }
    }
}
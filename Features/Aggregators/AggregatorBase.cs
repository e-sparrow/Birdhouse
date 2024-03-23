using System.Collections.Generic;
using Birdhouse.Features.Aggregators.Interfaces;

namespace Birdhouse.Features.Aggregators
{
    public abstract class AggregatorBase<T> 
        : IAggregator<T>
    {
        protected AggregatorBase(IEnumerable<Aggregation<T>> aggregations = null)
        {
            aggregations ??= new List<Aggregation<T>>();
            
            _aggregations = new List<Aggregation<T>>(aggregations);
        }
        
        public event Aggregation<T> OnProcess
        {
            add => _aggregations.Add(value);
            remove => _aggregations.Remove(value);
        }

        private readonly ICollection<Aggregation<T>> _aggregations;

        protected abstract T ProcessInternal(T source);
        
        public T Process(T source)
        {
            var processed = ProcessInternal(source);

            foreach (var evaluator in _aggregations)
            {
                processed = evaluator.Invoke(processed);
            }
            
            return processed;
        }
    }
}
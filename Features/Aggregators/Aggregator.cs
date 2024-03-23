using System.Collections.Generic;

namespace Birdhouse.Features.Aggregators
{
    public sealed class Aggregator<T>
        : AggregatorBase<T>
    {
        public Aggregator(IEnumerable<Aggregation<T>> aggregations = null)
            : base(aggregations)
        {
            
        }
        
        protected override T ProcessInternal(T source)
        {
            return source;
        }
    }
}
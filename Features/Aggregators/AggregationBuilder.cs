using Birdhouse.Features.Aggregators.Interfaces;

namespace Birdhouse.Features.Aggregators
{
    public sealed class AggregationBuilder<T>
        : IAggregationBuilder<AggregationBuilder<T>, T>
    {
        private readonly IAggregator<T> _result = new Aggregator<T>();
        
        public IAggregator<T> Build()
        {
            return _result;
        }

        public AggregationBuilder<T> Then(IAggregator<T> aggregator)
        {
            _result.OnProcess += aggregator.Process;
            return this;
        }

        public AggregationBuilder<T> Then(Aggregation<T> aggregation)
        {
            _result.OnProcess += aggregation;
            return this;
        }
    }
}
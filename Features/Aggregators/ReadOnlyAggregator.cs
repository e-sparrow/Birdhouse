namespace Birdhouse.Features.Aggregators
{
    public sealed class ReadOnlyAggregator<T>
        : ReadOnlyAggregatorBase<T>
    {
        public ReadOnlyAggregator(Aggregation<T> aggregator)
        {
            _aggregator = aggregator;
        }

        private readonly Aggregation<T> _aggregator;
        
        public override T Process(T source)
        {
            var result = _aggregator.Invoke(source);
            return result;
        }
    }
}
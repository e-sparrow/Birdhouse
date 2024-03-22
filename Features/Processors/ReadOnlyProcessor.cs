namespace Birdhouse.Features.Processors
{
    public sealed class ReadOnlyProcessor<T>
        : ReadOnlyProcessorBase<T>
    {
        public ReadOnlyProcessor(Aggregator<T> aggregator)
        {
            _aggregator = aggregator;
        }

        private readonly Aggregator<T> _aggregator;
        
        public override T Process(T source)
        {
            var result = _aggregator.Invoke(source);
            return result;
        }
    }
}
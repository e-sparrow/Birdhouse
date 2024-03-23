using Birdhouse.Features.Aggregators.Interfaces;

namespace Birdhouse.Features.Aggregators
{
    public abstract class ReadOnlyAggregatorBase<T>
        : IReadOnlyAggregator<T>
    {
        public abstract T Process(T source);
    }
}
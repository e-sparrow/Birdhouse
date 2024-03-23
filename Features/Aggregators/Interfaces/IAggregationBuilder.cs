using Birdhouse.Abstractions.Builders.Abstractions;

namespace Birdhouse.Features.Aggregators.Interfaces
{
    public interface IAggregationBuilder<out TSelf, T>
        : IBuilder<IAggregator<T>>
        where TSelf : IAggregationBuilder<TSelf, T>
    {
        TSelf Then(IAggregator<T> aggregator);
        TSelf Then(Aggregation<T> aggregation);
    }
}
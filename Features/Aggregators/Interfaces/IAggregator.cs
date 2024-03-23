namespace Birdhouse.Features.Aggregators.Interfaces
{
    public interface IAggregator<T> 
        : IReadOnlyAggregator<T>
    {
        event Aggregation<T> OnProcess;
    }
}
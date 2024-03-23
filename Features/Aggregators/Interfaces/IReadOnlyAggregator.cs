namespace Birdhouse.Features.Aggregators.Interfaces
{
    public interface IReadOnlyAggregator<T>
    {
        T Process(T source);
    }
}
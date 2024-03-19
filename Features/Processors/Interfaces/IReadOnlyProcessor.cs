namespace Birdhouse.Features.Processors.Interfaces
{
    public interface IReadOnlyProcessor<T>
    {
        T Process(T source);
    }
}
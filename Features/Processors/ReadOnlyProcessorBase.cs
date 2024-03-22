using Birdhouse.Features.Processors.Interfaces;

namespace Birdhouse.Features.Processors
{
    public abstract class ReadOnlyProcessorBase<T>
        : IReadOnlyProcessor<T>
    {
        public abstract T Process(T source);
    }
}
namespace Birdhouse.Features.Processors
{
    public sealed class Processor<T>
        : ProcessorBase<T>
    {
        protected override T ProcessInternal(T source)
        {
            return source;
        }
    }
}
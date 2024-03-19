namespace Birdhouse.Features.Processors.Interfaces
{
    public interface IProcessor<T> 
        : IReadOnlyProcessor<T>
    {
        event Evaluator<T> OnProcess;
    }
}
namespace Birdhouse.Tools.Processors.Interfaces
{
    public interface IProcessor<T>
    {
        event Evaluator<T> OnProcess;

        T Process(T source);
    }
}
namespace Birdhouse.Features.Executions.Interfaces
{
    public interface IExecutor
    {
        void Execute();
    }
    
    public interface IExecutor<in T>
    {
        void Execute(T input);
    }
}
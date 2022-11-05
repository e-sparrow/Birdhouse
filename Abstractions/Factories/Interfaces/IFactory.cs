namespace Birdhouse.Abstractions.Factories.Interfaces
{
    public interface IFactory<out TResult>
    {
        TResult Create();
    }
    
    public interface IFactory<out TResult, in TArgument>
    {
        TResult Create(TArgument argument);
    }
}
namespace Birdhouse.Features.DI.Interfaces
{
    public interface IResolver<TResult>
    {
        bool TryResolve(out TResult result);
    }
    
    public interface IResolver<TResult, in TArgument>
    {
        bool TryResolve(TArgument argument, out TResult result);
    }
}
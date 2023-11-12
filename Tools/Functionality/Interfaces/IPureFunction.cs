namespace Birdhouse.Tools.Functionality.Interfaces
{
    public interface IPureFunction<in TArgument, out TResult>
    {
        TResult Execute(TArgument argument);
    }
}
namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface IExceptionHandler
    {
        void Handle();
    }

    public interface IResultingExceptionHandler<out TResult>
    {
        TResult Handle();
    }
}

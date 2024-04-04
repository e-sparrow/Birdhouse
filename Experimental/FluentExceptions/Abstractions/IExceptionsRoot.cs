namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface IExceptionsRoot
        : IReadOnlyExceptionsRoot, IWriteOnlyExceptionsRoot
    {
        
    }
    
    public interface IResultingExceptionsRoot<TResult>
        : IReadOnlyResultingExceptionsRoot<TResult>, IWriteOnlyResultingExceptionsRoot<TResult>
    {
        
    }
}
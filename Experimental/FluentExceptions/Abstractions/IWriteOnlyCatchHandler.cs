using System;

namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface IWriteOnlyCatchHandler
    {
        bool CanHandle<TException>(TException exception);
        
        void Handle<TException>(TException exception)
            where TException : Exception;
    }

    public interface IWriteOnlyResultingCatchHandler<out TResult>
    {
        bool CanHandle<TException>(TException exception);
        
        TResult Handle<TException>(TException exception)
            where TException : Exception;
    }
}
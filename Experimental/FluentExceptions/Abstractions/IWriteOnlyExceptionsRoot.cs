using System;

namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface IWriteOnlyExceptionsRoot
    {
        void Execute(IWriteOnlyCatchHandler catchHandler, Action onFinally);
    }
    
    public interface IWriteOnlyResultingExceptionsRoot<TResult>
    {
        TResult Execute(IWriteOnlyResultingCatchHandler<TResult> catchHandler, Action onFinally);
    }
}
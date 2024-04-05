using System;

namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface IReadOnlyExceptionsRoot
    {
        IReadOnlyCatchHandler Catch(Action<Exception> onCatch);
        IReadOnlyCatchHandler<TException> CatchType<TException>(Action<TException> onCatch)
            where TException : Exception;
    }

    public interface IReadOnlyResultingExceptionsRoot<TResult>
    {
        IReadOnlyResultingCatchHandler<TResult> Catch(Func<Exception, TResult> onCatch);
        IReadOnlyResultingCatchHandler<TResult, TException> CatchType<TException>(Func<TException, TResult> onCatch)
            where TException : Exception;
    }
}
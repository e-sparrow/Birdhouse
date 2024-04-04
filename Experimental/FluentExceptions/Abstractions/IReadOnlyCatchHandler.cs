using System;

namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface IReadOnlyCatchHandler
        : IExceptionHandler
    {
        IExceptionHandler Finally(Action onFinally);
    }

    public interface IReadOnlyCatchHandler<TException>
        : IReadOnlyCatchHandler
        where TException : Exception
    {
        IReadOnlyCatchHandler<TOther> Or<TOther>(Action<TOther> onCatchOther)
            where TOther : Exception;

        IReadOnlyCatchHandler Default(Action<Exception> onCatchOther);
    }

    public interface IReadOnlyResultingCatchHandler<out TResult>
        : IResultingExceptionHandler<TResult>
    {
        IResultingExceptionHandler<TResult> Finally(Action onFinally);
    }

    public interface IReadOnlyResultingCatchHandler<TResult, TException>
        : IReadOnlyResultingCatchHandler<TResult>
        where TException : Exception
    {
        IReadOnlyResultingCatchHandler<TResult, TOther> Or<TOther>(Func<TOther, TResult> onCatchOther)
            where TOther : Exception;

        IReadOnlyResultingCatchHandler<TResult> Default(Func<Exception, TResult> onCatchOther);
    }
}
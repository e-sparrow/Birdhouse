using System;

namespace Birdhouse.Experimental.FluentExceptions.Abstractions
{
    public interface ICatchHandler
        : IReadOnlyCatchHandler, IWriteOnlyCatchHandler
    {
        
    }

    public interface ICatchHandler<TTarget>
        : ICatchHandler, IReadOnlyCatchHandler<TTarget>
        where TTarget : Exception
    {
        
    }

    public interface IResultingCatchHandler<out TResult>
        : IReadOnlyResultingCatchHandler<TResult>, IWriteOnlyResultingCatchHandler<TResult>
    {
        
    }

    public interface IResultingCatchHandler<TResult, TTarget>
        : IResultingCatchHandler<TResult>, IReadOnlyResultingCatchHandler<TResult, TTarget>
        where TTarget : Exception
    {
        
    }
}
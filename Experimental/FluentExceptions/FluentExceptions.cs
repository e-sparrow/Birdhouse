using System;
using Birdhouse.Experimental.FluentExceptions.Abstractions;

namespace Birdhouse.Experimental.FluentExceptions
{
    public static class FluentExceptions
    {
        public static IReadOnlyExceptionsRoot Try(Action onTry)
        {
            var result = new ExceptionsRoot(onTry);
            return result;
        }
    }

    public static class FluentExceptions<TResult>
    {
        public static IReadOnlyResultingExceptionsRoot<TResult> Try(Func<TResult> onTry)
        {
            var result = new ResultingExceptionsRoot<TResult>(onTry);
            return result;
        }
    }
}
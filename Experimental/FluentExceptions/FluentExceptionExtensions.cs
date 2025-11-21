using System;
using Birdhouse.Common.Delegates;
using Birdhouse.Experimental.FluentExceptions.Abstractions;
using Birdhouse.Features.Aggregators;

namespace Birdhouse.Experimental.FluentExceptions
{
    public static class FluentExceptionExtensions
    {
        public static IReadOnlyCatchHandler Catch(this Action self, Action<Exception> onCatch) 
            => FluentExceptions.Try(self).Catch(onCatch);

        public static IReadOnlyCatchHandler<TException> CatchType<TException>
            (this Action self, Action<TException> onCatch)
            where TException : Exception => FluentExceptions.Try(self).CatchType(onCatch);
            
        public static IReadOnlyResultingCatchHandler<TResult> Catch<TResult>
            (this Func<TResult> self, Func<Exception, TResult> onCatch) => FluentExceptions<TResult>.Try(self).CatchType(onCatch);

        public static IReadOnlyResultingCatchHandler<TResult, TException> CatchType<TResult, TException>
            (this Func<TResult> self, Func<TException, TResult> onCatch)
            where TException : Exception => FluentExceptions<TResult>.Try(self).CatchType(onCatch);

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> CatchType<TResult, TException>
            (this Func<TResult> self, ConditionalFunc<TException, TResult> onCatch)
            where TException : Exception
        {
            return FluentExceptions<(bool, TResult)>
                .Try(Success)
                .CatchType<TException>(Fail);

            (bool, TResult) Success() => new ValueTuple<bool, TResult>(true, self.Invoke());
            (bool, TResult) Fail(TException exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                return new ValueTuple<bool, TResult>(isSuccess, catchResult);
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> FalseIfCatch<TResult>(this Func<TResult> self)
        {
            return FluentExceptions<(bool, TResult)>
                .Try(Success)
                .Catch(HandleCatch);

            (bool, TResult) Success() => new ValueTuple<bool, TResult>(true, self.Invoke());
            (bool, TResult) HandleCatch(Exception exception) => new ValueTuple<bool, TResult>(false, default);
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> FalseIfCatchType<TResult, TException>
            (this Func<TResult> self) 
            where TException : Exception
        {
            return FluentExceptions<(bool, TResult)>
                .Try(Success)
                .CatchType<TException>(HandleCatch);

            (bool, TResult) Success() => new ValueTuple<bool, TResult>(true, self.Invoke());
            (bool, TResult) HandleCatch(TException exception) => new ValueTuple<bool, TResult>(false, default);
            
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> FalseIfCatchType<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self) 
            where TException : Exception
        {
            return self.Or<TException>(HandleCatch);

            (bool, TResult) HandleCatch(TException exception) => new ValueTuple<bool, TResult>(false, default);
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> Or<TResult, TPrevious, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TPrevious> self, ConditionalFunc<TException, TResult> onCatch)
            where TException : Exception
            where TPrevious : Exception
        {
            return self.Or<TException>(HandleCatch);

            (bool, TResult) HandleCatch(TException exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                return new ValueTuple<bool, TResult>(isSuccess, catchResult);
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> Else<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self, ConditionalFunc<Exception, TResult> onCatch) 
            where TException : Exception
        {
            return self.Default(HandleCatch);

            (bool, TResult) HandleCatch(Exception exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                return new ValueTuple<bool, TResult>(isSuccess, catchResult);
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> ElseFalse<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self) 
            where TException : Exception
        {
            return self.Default(HandleCatch);
            
            (bool, TResult) HandleCatch(Exception exception) => new ValueTuple<bool, TResult>(false, default);
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> ElseThrow<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self, Func<Exception> exceptionCreator)
            where TException : Exception
        {
            return self.Default(HandleCatch);;
            
            (bool, TResult) HandleCatch(Exception exception) => throw exceptionCreator.Invoke();
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> ElseThrow<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self)
            where TException : Exception
        {
            return self.Default(HandleCatch);
            
            (bool, TResult) HandleCatch(Exception exception) => throw exception;
        }

        public static bool TryHandle<TResult>
            (this IReadOnlyResultingCatchHandler<(bool, TResult)> self, out TResult result)
        {
            var pairResult = self.Handle();

            result = pairResult.Item2;
            return pairResult.Item1;
        }
    }
}
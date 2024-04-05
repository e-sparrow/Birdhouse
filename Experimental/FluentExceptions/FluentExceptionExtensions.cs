using System;
using Birdhouse.Common.Delegates;
using Birdhouse.Experimental.FluentExceptions.Abstractions;
using Birdhouse.Features.Aggregators;

namespace Birdhouse.Experimental.FluentExceptions
{
    public static class FluentExceptionExtensions
    {
        public static IReadOnlyCatchHandler Catch(this Action self, Action<Exception> onCatch)
        {
            var result = FluentExceptions
                .Try(self)
                .Catch(onCatch);

            return result;
        }

        public static IReadOnlyCatchHandler<TException> CatchType<TException>
            (this Action self, Action<TException> onCatch)
            where TException : Exception
        {
            var result = FluentExceptions
                .Try(self)
                .CatchType(onCatch);

            return result;
        }

        public static IReadOnlyResultingCatchHandler<TResult> Catch<TResult>
            (this Func<TResult> self, Func<Exception, TResult> onCatch)
        {
            var result = FluentExceptions<TResult>
                .Try(self)
                .CatchType(onCatch);

            return result;
        }

        public static IReadOnlyResultingCatchHandler<TResult, TException> CatchType<TResult, TException>
            (this Func<TResult> self, Func<TException, TResult> onCatch)
            where TException : Exception
        {
            var result = FluentExceptions<TResult>
                .Try(self)
                .CatchType(onCatch);

            return result;
        }

        public static bool Catch<TResult>(this Func<TResult> self, ConditionalFunc<Exception, TResult> onCatch, out TResult result)
        {
            var handleResult = FluentExceptions<(bool, TResult)>
                .Try(Success)
                .Catch(Fail)
                .Handle();

            result = handleResult.Item2;
            return handleResult.Item1;

            (bool, TResult) Success()
            {
                var successResult = new ValueTuple<bool, TResult>(true, self.Invoke());
                return successResult;
            }

            (bool, TResult) Fail(Exception exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                
                var resultTuple = new ValueTuple<bool, TResult>(isSuccess, catchResult);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> CatchType<TResult, TException>
            (this Func<TResult> self, ConditionalFunc<TException, TResult> onCatch)
            where TException : Exception
        {
            var result = FluentExceptions<(bool, TResult)>
                .Try(Success)
                .CatchType<TException>(Fail);

            return result;

            (bool, TResult) Success()
            {
                var successResult = new ValueTuple<bool, TResult>(true, self.Invoke());
                return successResult;
            }

            (bool, TResult) Fail(TException exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                
                var resultTuple = new ValueTuple<bool, TResult>(isSuccess, catchResult);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> FalseIfCatch<TResult>(this Func<TResult> self)
        {
            var result = FluentExceptions<(bool, TResult)>
                .Try(Success)
                .Catch(HandleCatch);

            return result;

            (bool, TResult) Success()
            {
                var successResult = new ValueTuple<bool, TResult>(true, self.Invoke());
                return successResult;
            }

            (bool, TResult) HandleCatch(Exception exception)
            {
                var resultTuple = new ValueTuple<bool, TResult>(false, default);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> FalseIfCatchType<TResult, TException>
            (this Func<TResult> self) 
            where TException : Exception
        {
            var result = FluentExceptions<(bool, TResult)>
                .Try(Success)
                .CatchType<TException>(HandleCatch);

            return result;

            (bool, TResult) Success()
            {
                var successResult = new ValueTuple<bool, TResult>(true, self.Invoke());
                return successResult;
            }

            (bool, TResult) HandleCatch(TException exception)
            {
                var resultTuple = new ValueTuple<bool, TResult>(false, default);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> FalseIfCatchType<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self) 
            where TException : Exception
        {
            var result = self
                .Or<TException>(HandleCatch);

            return result;

            (bool, TResult) HandleCatch(TException exception)
            {
                var resultTuple = new ValueTuple<bool, TResult>(false, default);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult), TException> Or<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self, ConditionalFunc<TException, TResult> onCatch)
            where TException : Exception
        {
            var result = self
                .Or<TException>(HandleCatch);

            return result;

            (bool, TResult) HandleCatch(TException exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                
                var resultTuple = new ValueTuple<bool, TResult>(isSuccess, catchResult);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> Else<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self, ConditionalFunc<Exception, TResult> onCatch) 
            where TException : Exception
        {
            var result = self
                .Default(HandleCatch);

            return result;

            (bool, TResult) HandleCatch(Exception exception)
            {
                var isSuccess = onCatch.Invoke(exception, out var catchResult);
                
                var resultTuple = new ValueTuple<bool, TResult>(isSuccess, catchResult);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> ElseFalse<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self) 
            where TException : Exception
        {
            var result = self
                .Default(HandleCatch);

            return result;


            (bool, TResult) HandleCatch(Exception exception)
            {
                var resultTuple = new ValueTuple<bool, TResult>(false, default);
                return resultTuple;
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> ElseThrow<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self, Func<Exception> exceptionCreator)
            where TException : Exception
        {
            var result = self
                .Default(HandleCatch);

            return result;


            (bool, TResult) HandleCatch(Exception exception)
            {
                throw exceptionCreator.Invoke();
            }
        }

        public static IReadOnlyResultingCatchHandler<(bool, TResult)> ElseThrow<TResult, TException>
            (this IReadOnlyResultingCatchHandler<(bool, TResult), TException> self)
            where TException : Exception
        {
            var result = self
                .Default(HandleCatch);

            return result;


            (bool, TResult) HandleCatch(Exception exception)
            {
                throw exception;
            }
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
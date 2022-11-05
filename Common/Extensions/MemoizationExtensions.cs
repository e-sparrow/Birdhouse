using System;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Functionality;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class MemoizationExtensions
    {
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>
            (this Func<TArgument, TResult> func, IMemoizationBuffer<TArgument, TResult> buffer = default)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<TArgument, TResult>();
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }   
        
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>
            (this Func<TArgument, TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<TArgument, TResult> buffer = default)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<TArgument, TResult>(elementLifetime);
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                var result = pureFunction.Execute(argument);
                return result;
            }
        }
        
        public static Func<TArgument, TResult> AsPure<TArgument, TResult>
            (this Func<TArgument, TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<TArgument, TResult> buffer = default)
        {
            return Execute;

            TResult Execute(TArgument argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<TArgument, TResult>(termInfoCreator);
                var pureFunction = new PureFunction<TArgument, TResult>(buffer, func);

                var result = pureFunction.Execute(argument);
                return result;
            }
        }

        public static Func<T1, T2, TResult> AsPure<T1, T2, TResult>
            (this Func<T1, T2, TResult> func, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(buffer)
                .TypeArgumentsBack<T1, T2, TResult>();
        
            return result;
        }
        
        public static Func<T1, T2, T3, TResult> AsPure<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> func, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(buffer)
                .TypeArgumentsBack<T1, T2, T3, TResult>();
        
            return result;
        }
        
        public static Func<T1, T2, T3, T4, TResult> AsPure<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> func, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(buffer)
                .TypeArgumentsBack<T1, T2, T3, T4, TResult>();
        
            return result;
        }
        
        public static Func<T1, T2, T3, T4, T5, TResult> AsPure<T1, T2, T3, T4, T5, TResult>
            (this Func<T1, T2, T3, T4, T5, TResult> func, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(buffer)
                .TypeArgumentsBack<T1, T2, T3, T4, T5, TResult>();
        
            return result;
        }

        public static Func<T1, T2, TResult> AsPure<T1, T2, TResult>
            (this Func<object[], TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(elementLifetime, buffer)
                .TypeArgumentsBack<T1, T2, TResult>();
        
            return result;
        }

        public static Func<T1, T2, T3, TResult> AsPure<T1, T2, T3, TResult>
            (this Func<object[], TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(elementLifetime, buffer)
                .TypeArgumentsBack<T1, T2, T3, TResult>();
        
            return result;
        }
        
        public static Func<T1, T2, T3, T4, TResult> AsPure<T1, T2, T3, T4, TResult>
            (this Func<object[], TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(elementLifetime, buffer)
                .TypeArgumentsBack<T1, T2, T3, T4, TResult>();
            
            return result;
        }
        
        public static Func<T1, T2, T3, T4, T5, TResult> AsPure<T1, T2, T3, T4, T5, TResult>
            (this Func<object[], TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(elementLifetime, buffer)
                .TypeArgumentsBack<T1, T2, T3, T4, T5, TResult>();
            
            return result;
        }

        public static Func<T1, T2, TResult> AsPure<T1, T2, TResult>
            (this Func<object[], TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(termInfoCreator, buffer)
                .TypeArgumentsBack<T1, T2, TResult>();
            
            return result;
        }

        public static Func<T1, T2, T3, TResult> AsPure<T1, T2, T3, TResult>
            (this Func<object[], TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(termInfoCreator, buffer)
                .TypeArgumentsBack<T1, T2, T3, TResult>();
            
            return result;
        }

        public static Func<T1, T2, T3, T4, TResult> AsPure<T1, T2, T3, T4, TResult>
            (this Func<object[], TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(termInfoCreator, buffer)
                .TypeArgumentsBack<T1, T2, T3, T4, TResult>();
            
            return result;
        }

        public static Func<T1, T2, T3, T4, T5, TResult> AsPure<T1, T2, T3, T4, T5, TResult>
            (this Func<object[], TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            var result = func
                .UntypedArguments()
                .AsPure(termInfoCreator, buffer)
                .TypeArgumentsBack<T1, T2, T3, T4, T5, TResult>();
            
            return result;
        }

        public static TResult GetOrCreate<T1, T2, TResult>
            (this IMemoizationBuffer<object[], object> buffer, T1 arg1, T2 arg2, Func<T1, T2, TResult> func)
        {
            var args = TypingHelper.Args(arg1, arg2);

            var value = (TResult) buffer.GetOrCreate(args, Invoke);
            return value;

            object Invoke()
            {
                var result = func.Invoke(arg1, arg2);
                return result;
            }
        }

        public static TResult GetOrCreate<T1, T2, T3, TResult>
            (this IMemoizationBuffer<object[], object> buffer, T1 arg1, T2 arg2, T3 arg3, Func<T1, T2, T3, TResult> func)
        {
            var args = TypingHelper.Args(arg1, arg2, arg3);

            var value = (TResult) buffer.GetOrCreate(args, Invoke);
            return value;

            object Invoke()
            {
                var result = func.Invoke(arg1, arg2, arg3);
                return result;
            }
        }

        public static TResult GetOrCreate<T1, T2, T3, T4, TResult>
            (this IMemoizationBuffer<object[], object> buffer, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<T1, T2, T3, T4, TResult> func)
        {
            var args = TypingHelper.Args(arg1, arg2, arg3, arg4);

            var value = (TResult) buffer.GetOrCreate(args, Invoke);
            return value;

            object Invoke()
            {
                var result = func.Invoke(arg1, arg2, arg3, arg4);
                return result;
            }
        }

        public static TResult GetOrCreate<T1, T2, T3, T4, T5, TResult>
            (this IMemoizationBuffer<object[], object> buffer, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            var args = TypingHelper.Args(arg1, arg2, arg3, arg4, arg5);

            var value = (TResult) buffer.GetOrCreate(args, Invoke);
            return value;

            object Invoke()
            {
                var result = func.Invoke(arg1, arg2, arg3, arg4, arg5);
                return result;
            }
        }

        private static Func<object[], TResult> AsPure<TResult>
            (this Func<object[], TResult> func, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            return Execute;

            TResult Execute(object[] argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<object[], TResult>();
                var pureFunction = new PureFunction<object[], TResult>(buffer, func);

                var result = pureFunction.Execute(argument);
                return result;
            }
        }   
        
        private static Func<object[], TResult> AsPure<TResult>
            (this Func<object[], TResult> func, TimeSpan elementLifetime, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            return Execute;

            TResult Execute(object[] argument)
            {
                buffer ??= MemoizationHelper.CreateBuffer<object[], TResult>(elementLifetime);
                var pureFunction = new PureFunction<object[], TResult>(buffer, func);

                return pureFunction.Execute(argument);
            }
        }
        private static Func<object[], TResult> AsPure<TResult>
            (this Func<object[], TResult> func, Func<ITermInfo> termInfoCreator, IMemoizationBuffer<object[], TResult> buffer = default)
        {
            return Execute;

            TResult Execute(object[] arguments)
            {
                buffer ??= MemoizationHelper.CreateBuffer<object[], TResult>(termInfoCreator);
                var pureFunction = new PureFunction<object[], TResult>(buffer, func);

                return pureFunction.Execute(arguments);
            }
        }
    }
}

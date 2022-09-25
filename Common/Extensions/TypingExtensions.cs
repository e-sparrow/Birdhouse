using System;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Common.Extensions
{
    public static class TypingExtensions
    {
        public static Action<object[]> Untyped<T1, T2>(this Action<T1, T2> action)
        {
            return array => action.Invoke((T1) array[0], (T2) array[1]);
        }

        public static Action<object[]> Untyped<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            return array => action.Invoke((T1) array[0], (T2) array[1], (T3) array[2]);
        }

        public static Action<object[]> Untyped<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            return array => action.Invoke((T1) array[0], (T2) array[1], (T3) array[2], (T4) array[3]);
        }

        public static Action<object[]> Untyped<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
        {
            return array => action.Invoke((T1) array[0], (T2) array[1], (T3) array[2], (T4) array[3], (T5) array[4]);
        }

        public static Func<object[], object> Untyped<T, TResult>(this Func<T, TResult> func)
        {
            return array => func.Invoke((T) array[0]);
        }

        public static Func<object[], object> Untyped<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1]);
        }

        public static Func<object[], object> Untyped<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1], (T3) array[2]);
        }

        public static Func<object[], object> Untyped<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1], (T3) array[2], (T4) array[3]);
        }

        public static Func<object[], object> Untyped<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1], (T3) array[2], (T4) array[3], (T5) array[4]);
        }

        public static Func<object[], TResult> UntypedArguments<T, TResult>(this Func<T, TResult> func)
        {
            return array => func.Invoke((T) array[0]);
        }

        public static Func<object[], TResult> UntypedArguments<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1]);
        }

        public static Func<object[], TResult> UntypedArguments<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1], (T3) array[2]);
        }

        public static Func<object[], TResult> UntypedArguments<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1], (T3) array[2], (T4) array[3]);
        }

        public static Func<object[], TResult> UntypedArguments<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return array => func.Invoke((T1) array[0], (T2) array[1], (T3) array[2], (T4) array[3], (T5) array[4]);
        }

        public static Func<T, object> UntypedResult<T, TResult>(this Func<T, TResult> func)
        {
            return arg => func.Invoke(arg);
        }

        public static Func<T1, T2, object> UntypedResult<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
            return (arg1, arg2) => func.Invoke(arg1, arg2);
        }

        public static Func<T1, T2, T3, object> UntypedResult<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
            return (arg1, arg2, arg3) => func.Invoke(arg1, arg2, arg3);
        }

        public static Func<T1, T2, T3, T4, object> UntypedResult<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
            return (arg1, arg2, arg3, arg4) => func.Invoke(arg1, arg2, arg3, arg4);
        }

        public static Func<T1, T2, T3, T4, T5, object> UntypedResult<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return (arg1, arg2, arg3, arg4, arg5) => func.Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        public static Func<T, TResult> TypeBack<T, TResult>(this Func<object[], object> func)
        {
            return arg => (TResult) func.Invoke(TypingHelper.Args(arg));
        }

        public static Func<T1, T2, TResult> TypeBack<T1, T2, TResult>(this Func<object[], object> func)
        {
            return (arg1, arg2) => (TResult) func.Invoke(TypingHelper.Args(arg1, arg2));
        }

        public static Func<T1, T2, T3, TResult> TypeBack<T1, T2, T3, TResult>(this Func<object[], object> func)
        {
            return (arg1, arg2, arg3 ) => (TResult) func.Invoke(TypingHelper.Args(arg1, arg2, arg3));
        }
        
        public static Func<T1, T2, T3, T4, TResult> TypeBack<T1, T2, T3, T4, TResult>(this Func<object[], object> func)
        {
            return (arg1, arg2, arg3 , arg4) => (TResult) func.Invoke(TypingHelper.Args(arg1, arg2, arg3, arg4));
        }
        
        public static Func<T1, T2, T3, T4, T5, TResult> TypeBack<T1, T2, T3, T4, T5, TResult>(this Func<object[], object> func)
        {
            return (arg1, arg2, arg3 , arg4, arg5) => (TResult) func.Invoke(TypingHelper.Args(arg1, arg2, arg3, arg4, arg5));
        }
        
        public static Func<T1, T2, TResult> TypeArgumentsBack<T1, T2, TResult>(this Func<object[], TResult> func)
        {
            return (arg1, arg2) => func.Invoke(TypingHelper.Args(arg1, arg2));
        }

        public static Func<T1, T2, T3, TResult> TypeArgumentsBack<T1, T2, T3, TResult>(this Func<object[], TResult> func)
        {
            return (arg1, arg2, arg3) => func.Invoke(TypingHelper.Args(arg1, arg2, arg3));
        }
        
        public static Func<T1, T2, T3, T4, TResult> TypeArgumentsBack<T1, T2, T3, T4, TResult>(this Func<object[], TResult> func)
        {
            return (arg1, arg2, arg3 , arg4) => func.Invoke(TypingHelper.Args(arg1, arg2, arg3, arg4));
        }
        
        public static Func<T1, T2, T3, T4, T5, TResult> TypeArgumentsBack<T1, T2, T3, T4, T5, TResult>(this Func<object[], TResult> func)
        {
            return (arg1, arg2, arg3 , arg4, arg5) => func.Invoke(TypingHelper.Args(arg1, arg2, arg3, arg4, arg5));
        }

        public static Func<T, TResult> TypeResultBack<T, TResult>(this Func<T, object> func)
        {
            return arg => (TResult) func.Invoke(arg);
        }

        public static Func<T1, T2, TResult> TypeResultBack<T1, T2, TResult>(this Func<T1, T2, object> func)
        {
            return (arg1, arg2) => (TResult) func.Invoke(arg1, arg2);
        }
        
        public static Func<T1, T2, T3, TResult> TypeResultBack<T1, T2, T3, TResult>(this Func<T1, T2, T3, object> func)
        {
            return (arg1, arg2, arg3) => (TResult) func.Invoke(arg1, arg2, arg3);
        }
        
        public static Func<T1, T2, T3, T4, TResult> TypeResultBack<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, object> func)
        {
            return (arg1, arg2, arg3, arg4) => (TResult) func.Invoke(arg1, arg2, arg3, arg4);
        }
        
        public static Func<T1, T2, T3, T4, T5, TResult> TypeResultBack<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, object> func)
        {
            return (arg1, arg2, arg3, arg4, arg5) => (TResult) func.Invoke(arg1, arg2, arg3, arg4, arg5);
        }
    }
}
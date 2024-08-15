using System;
using System.Threading.Tasks;
using Birdhouse.Common.Exceptions;
using Birdhouse.Experimental.FluentExceptions;
using Birdhouse.Experimental.FluentExceptions.Abstractions;
using UnityEngine.XR;

namespace Birdhouse.Common.Tasks
{
    public static class TaskExtensions
    {
        public static IReadOnlyResultingCatchHandler<Task> RetryIfCatch(this Task task, int maxTries = 1)
        {
            var result = FluentExceptions<Task>
                .Try(() => task)
                .Catch(HandleCatch);

            return result;
            
            Task HandleCatch(Exception exception)
            {
                if (maxTries > 1)
                {
                    var handleResult = task.RetryIfCatch(maxTries - 1).Handle();
                    return handleResult;   
                }

                var maxTriesResult = Task.FromException(exception);
                return maxTriesResult;
            }
        }
        
        public static IReadOnlyResultingCatchHandler<Task, TException> RetryIfCatchType<TException>
            (this Task task, int maxTries = 1) 
            where TException : Exception
        {
            var result = FluentExceptions<Task>
                .Try(() => task)
                .CatchType<TException>(HandleCatch);

            return result;
            
            Task HandleCatch(TException exception)
            {
                if (maxTries > 1)
                {
                    var handleResult = task.RetryIfCatch(maxTries - 1).Handle();
                    return handleResult;   
                }

                var maxTriesResult = Task.FromException(exception);
                return maxTriesResult;
            }
        }
        
        public static IReadOnlyResultingCatchHandler<Task<T>> RetryIfCatch<T>(this Task<T> task, int maxTries = 1)
        {
            var result = FluentExceptions<Task<T>>
                .Try(() => task)
                .Catch(HandleCatch);

            return result;

            Task<T> HandleCatch(Exception exception)
            {
                if (maxTries > 1)
                {
                    var handleResult = task.RetryIfCatch(maxTries - 1).Handle();
                    return handleResult;   
                }

                var maxTriesResult = Task.FromException<T>(exception);
                return maxTriesResult;
            }
        }
        
        public static IReadOnlyResultingCatchHandler<Task<TResult>, TException> RetryIfCatchType<TResult, TException>
            (this Task<TResult> task, int maxTries = 1) 
            where TException : Exception
        {
            var result = FluentExceptions<Task<TResult>>
                .Try(() => task)
                .CatchType<TException>(HandleCatch);

            return result;
            
            Task<TResult> HandleCatch(TException exception)
            {
                if (maxTries > 1)
                {
                    var handleResult = task.RetryIfCatchType<TResult, TException>(maxTries - 1).Handle();
                    return handleResult;   
                }

                var maxTriesResult = Task.FromException<TResult>(exception);
                return maxTriesResult;
            }
        }
    }
}
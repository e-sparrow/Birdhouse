using System;
using Birdhouse.Experimental.FluentExceptions.Abstractions;

namespace Birdhouse.Experimental.FluentExceptions
{
    public sealed class ExceptionsRoot
        : IExceptionsRoot
    {
        public ExceptionsRoot(Action onTry)
        {
            _onTry = onTry;
        }

        private readonly Action _onTry;

        public IReadOnlyCatchHandler Catch(Action<Exception> onCatch)
        {
            var handler = new CatchHandler(this, onCatch);
            return handler;
        }

        public IReadOnlyCatchHandler<TException> CaughtType<TException>(Action<TException> onCatch)
            where TException : Exception
        {
            var handler = new CatchHandler<TException>(this, onCatch);
            return handler;
        }

        public void Execute(IWriteOnlyCatchHandler catchHandler, Action onFinally)
        {
            try
            {
                _onTry.Invoke();
            }
            catch (Exception exception)
            {
                catchHandler.Handle(exception);
            }
            finally
            {
                onFinally.Invoke();
            }
        }
    }
    
    public sealed class ResultingExceptionsRoot<TResult>
        : IResultingExceptionsRoot<TResult>
    {
        public ResultingExceptionsRoot(Func<TResult> onSuccess)
        {
            _onSuccess = onSuccess;
        }

        private readonly Func<TResult> _onSuccess;
        
        public IReadOnlyResultingCatchHandler<TResult> Catch(Func<Exception, TResult> onCatch)
        {
            var result = new ResultingCatchHandler<TResult>(this, onCatch);
            return result;
        }

        public IReadOnlyResultingCatchHandler<TResult, TException> CaughtType<TException>(Func<TException, TResult> onCatch) 
            where TException : Exception
        {
            var result = new ResultingCatchHandler<TResult, TException>(this, onCatch);
            return result;
        }

        public TResult Execute(IWriteOnlyResultingCatchHandler<TResult> catchHandler, Action onFinally)
        {
            try
            {
                return _onSuccess.Invoke();
            }
            catch (Exception exception)
            {
                return catchHandler.Handle(exception);
            }
            finally
            {
                onFinally.Invoke();
            }
        }
    }
}
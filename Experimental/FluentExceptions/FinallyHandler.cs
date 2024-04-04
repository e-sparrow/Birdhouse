using System;
using Birdhouse.Experimental.FluentExceptions.Abstractions;

namespace Birdhouse.Experimental.FluentExceptions
{
    public sealed class FinallyHandler
        : IExceptionHandler
    {
        public FinallyHandler(IWriteOnlyExceptionsRoot root, IWriteOnlyCatchHandler catchHandler, Action onFinally)
        {
            _root = root;
            _catchHandler = catchHandler;
            _onFinally = onFinally;
        }

        private readonly IWriteOnlyExceptionsRoot _root;
        private readonly IWriteOnlyCatchHandler _catchHandler;
        private readonly Action _onFinally;

        public void Handle()
        {
            _root.Execute(_catchHandler, _onFinally);
        }
    }
    
    public sealed class ResultingFinallyHandler<TResult>
        : IResultingExceptionHandler<TResult>
    {
        public ResultingFinallyHandler
        (
            IWriteOnlyResultingExceptionsRoot<TResult> root, 
            IWriteOnlyResultingCatchHandler<TResult> catchHandler,
            Action onFinally
        )
        {
            _root = root;
            _catchHandler = catchHandler;
            _onFinally = onFinally;
        }
        
        private readonly IWriteOnlyResultingExceptionsRoot<TResult> _root;
        private readonly IWriteOnlyResultingCatchHandler<TResult> _catchHandler;
        private readonly Action _onFinally;
        
        public TResult Handle()
        {
            var result = _root.Execute(_catchHandler, _onFinally);
            return result;
        }
    }
}
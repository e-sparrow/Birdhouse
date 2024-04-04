using System;
using Birdhouse.Experimental.FluentExceptions.Abstractions;

namespace Birdhouse.Experimental.FluentExceptions
{
    public sealed class CatchHandler
        : ICatchHandler
    {
        public CatchHandler(IWriteOnlyExceptionsRoot root, Action<Exception> onCatch)
        {
            _root = root;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyExceptionsRoot _root;
        private readonly Action<Exception> _onCatch;

        public bool CanHandle<TException>(TException exception)
        {
            return true;
        }

        public void Handle<TException>(TException exception)
            where TException : Exception
        {
            _onCatch.Invoke(exception);
        }

        public IExceptionHandler Finally(Action onFinally)
        {
            var result = new FinallyHandler(_root, this, onFinally);
            return result;
        }

        public void Handle()
        {
            _root.Execute(this, () => { });
        }
    }
    
    public sealed class CatchHandler<TTarget>
        : ICatchHandler<TTarget>
        where TTarget : Exception
    {
        public CatchHandler(IWriteOnlyExceptionsRoot root, Action<TTarget> onCatch)
        {
            _root = root;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyExceptionsRoot _root;
        private readonly Action<TTarget> _onCatch;

        public IReadOnlyCatchHandler<TOther> Or<TOther>(Action<TOther> onCatchOther) 
            where TOther : Exception
        {
            var result = new CatchHandlerOrDecorator<TOther>(_root, this, onCatchOther);
            return result;
        }

        public IReadOnlyCatchHandler Default(Action<Exception> onCatchOther)
        {
            var result = new CatchHandlerElseDecorator(_root, this, onCatchOther);
            return result;
        }

        public bool CanHandle<TException>(TException exception)
        {
            var result = exception is TTarget;
            return result;
        }

        public void Handle<TException>(TException exception) 
            where TException : Exception
        {
            if (exception is TTarget target)
            {
                _onCatch.Invoke(target);
            }
        }

        public IExceptionHandler Finally(Action onFinally)
        {
            var result = new FinallyHandler(_root, this, onFinally);
            return result;
        }

        public void Handle()
        {
            _root.Execute(this, () => { });
        }
    }

    public sealed class CatchHandlerOrDecorator<TSelf>
        : ICatchHandler<TSelf>
        where TSelf : Exception
    {
        public CatchHandlerOrDecorator(IWriteOnlyExceptionsRoot root, ICatchHandler inner, Action<TSelf> onCatch)
        {
            _root = root;
            _inner = inner;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyExceptionsRoot _root;
        private readonly ICatchHandler _inner;
        private readonly Action<TSelf> _onCatch;
        
        public IReadOnlyCatchHandler<TOther> Or<TOther>(Action<TOther> onCatchOther) 
            where TOther : Exception
        {
            var result = new CatchHandlerOrDecorator<TOther>(_root, this, onCatchOther);
            return result;
        }

        public IReadOnlyCatchHandler Default(Action<Exception> onCatchOther)
        {
            var result = new CatchHandlerElseDecorator(_root, this, onCatchOther);
            return result;
        }

        public bool CanHandle<TException>(TException exception)
        {
            var result = exception is TSelf || _inner.CanHandle<TException>(exception);
            return result;
        }

        public void Handle<TException>(TException exception) 
            where TException : Exception
        {
            if (_inner.CanHandle<TException>(exception))
            {
                _inner.Handle(exception);
            }
            else if (exception is TSelf self)
            {
                _onCatch.Invoke(self);
            }
        }

        public IExceptionHandler Finally(Action onFinally)
        {
            var result = new FinallyHandler(_root, this, onFinally);
            return result;
        }
        
        public void Handle()
        {
            _root.Execute(this, () => { });
        }
    }

    public sealed class CatchHandlerElseDecorator
        : ICatchHandler
    {
        public CatchHandlerElseDecorator(IWriteOnlyExceptionsRoot root, ICatchHandler inner, Action<Exception> onCatch)
        {
            _root = root;
            _inner = inner;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyExceptionsRoot _root;
        private readonly ICatchHandler _inner;
        private readonly Action<Exception> _onCatch;

        public bool CanHandle<TException>(TException exception)
        {
            return true;
        }

        public void Handle<TException>(TException exception) 
            where TException : Exception
        {
            if (_inner.CanHandle<TException>(exception))
            {
                _inner.Handle(exception);
                return;
            }
            
            _onCatch.Invoke(exception);
        }
        
        public IExceptionHandler Finally(Action onFinally)
        {
            var result = new FinallyHandler(_root, this, onFinally);
            return result;
        }
        
        public void Handle()
        {
            _root.Execute(this, () => { });
        }
    }

    public sealed class ResultingCatchHandler<TResult>
        : IResultingCatchHandler<TResult>
    {
        public ResultingCatchHandler(IWriteOnlyResultingExceptionsRoot<TResult> root, Func<Exception, TResult> onCatch)
        {
            _root = root;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyResultingExceptionsRoot<TResult> _root;
        private readonly Func<Exception, TResult> _onCatch;

        public bool CanHandle<TException>(TException exception)
        {
            return true;
        }

        public TResult Handle<TException>(TException exception) 
            where TException : Exception
        {
            var result = _onCatch.Invoke(exception);
            return result;
        }

        public IResultingExceptionHandler<TResult> Finally(Action onFinally)
        {
            var result = new ResultingFinallyHandler<TResult>(_root, this, onFinally);
            return result;
        }
        
        public TResult Handle()
        {
            var result = _root.Execute(this, () => { });
            return result;
        }
    }

    public sealed class ResultingCatchHandler<TResult, TTarget>
        : IResultingCatchHandler<TResult, TTarget>
        where TTarget : Exception
    {
        public ResultingCatchHandler(IWriteOnlyResultingExceptionsRoot<TResult> root, Func<TTarget, TResult> onCatch)
        {
            _root = root;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyResultingExceptionsRoot<TResult> _root;
        private readonly Func<TTarget, TResult> _onCatch;
        

        public IReadOnlyResultingCatchHandler<TResult, TOther> Or<TOther>(Func<TOther, TResult> onCatchOther) 
            where TOther : Exception
        {
            var result = new ResultingCatchHandlerOrDecorator<TResult, TTarget, TOther>(_root, this, onCatchOther);
            return result;
        }

        public IReadOnlyResultingCatchHandler<TResult> Default(Func<Exception, TResult> onCatchOther)
        {
            var result = new ResultingCatchHandlerElseDecorator<TResult>(_root, this, onCatchOther);
            return result;
        }

        public IResultingExceptionHandler<TResult> Finally(Action onFinally)
        {
            var result = new ResultingFinallyHandler<TResult>(_root, this, onFinally);
            return result;
        }

        public bool CanHandle<TException>(TException exception)
        {
            var result = exception is TTarget;
            return result;
        }

        public TResult Handle<TException>(TException exception) 
            where TException : Exception
        {
            if (exception is TTarget target)
            {
                var result = _onCatch.Invoke(target);
                return result;
            }

            return default;
        }
        
        public TResult Handle()
        {
            var result = _root.Execute(this, () => { });
            return result;
        }
    }
    public sealed class ResultingCatchHandlerOrDecorator<TResult, TInner, TSelf>
        : IResultingCatchHandler<TResult, TSelf>
        where TInner : Exception
        where TSelf : Exception
    {
        public ResultingCatchHandlerOrDecorator
        (
            IWriteOnlyResultingExceptionsRoot<TResult> root, 
            IResultingCatchHandler<TResult, TInner> inner, 
            Func<TSelf, TResult> onCatch
        )
        {
            _root = root;
            _inner = inner;
            _onCatch = onCatch;
        }

        private readonly IWriteOnlyResultingExceptionsRoot<TResult> _root;
        private readonly IResultingCatchHandler<TResult, TInner> _inner;
        private readonly Func<TSelf, TResult> _onCatch;

        public IReadOnlyResultingCatchHandler<TResult, TOther> Or<TOther>(Func<TOther, TResult> onCatchOther) 
            where TOther : Exception
        {
            var result = new ResultingCatchHandlerOrDecorator<TResult, TSelf, TOther>(_root, this, onCatchOther);
            return result;
        }

        public IReadOnlyResultingCatchHandler<TResult> Default(Func<Exception, TResult> onCatchOther)
        {
            var result = new ResultingCatchHandlerElseDecorator<TResult>(_root, this, onCatchOther);
            return result;
        }
        
        public bool CanHandle<TException>(TException exception)
        {
            var result = exception is TSelf || _inner.CanHandle(exception);
            return result;
        }

        public TResult Handle<TException>(TException exception) 
            where TException : Exception
        {
            if (_inner.CanHandle<TException>(exception))
            {
                return _inner.Handle(exception);
            }

            if (exception is TSelf target)
            {
                return _onCatch.Invoke(target);
            }

            return default;
        }
        
        public IResultingExceptionHandler<TResult> Finally(Action onFinally)
        {
            var result = new ResultingFinallyHandler<TResult>(_root, this, onFinally);
            return result;
        }
        
        public TResult Handle()
        {
            var result = _root.Execute(this, () => { });
            return result;
        }
    }
    
    public sealed class ResultingCatchHandlerElseDecorator<TResult>
        : IResultingCatchHandler<TResult>
    {
        public ResultingCatchHandlerElseDecorator
        (
            IWriteOnlyResultingExceptionsRoot<TResult> root,
            IResultingCatchHandler<TResult> inner,
            Func<Exception, TResult> onCatch
        )
        {
            _root = root;
            _inner = inner;
            _onCatch = onCatch;
        }
        
        private readonly IWriteOnlyResultingExceptionsRoot<TResult> _root;
        private readonly IResultingCatchHandler<TResult> _inner;
        private readonly Func<Exception, TResult> _onCatch;

        public bool CanHandle<TException>(TException exception)
        {
            return true;
        }

        public TResult Handle<TException>(TException exception) 
            where TException : Exception
        {
            if (_inner.CanHandle<TException>(exception))
            {
                return _inner.Handle(exception);
            }

            return _onCatch.Invoke(exception);
        }

        public IResultingExceptionHandler<TResult> Finally(Action onFinally)
        {
            var result = new ResultingFinallyHandler<TResult>(_root, this, onFinally);
            return result;
        }
        
        public TResult Handle()
        {
            return _root.Execute(this, () => { });
        }
    }
}
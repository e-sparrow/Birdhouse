using System;

namespace Birdhouse.Abstractions.Disposables
{
    public class CallbackDisposable : DisposableBase
    {
        public CallbackDisposable(Action callback = null)
        {
            callback ??= () => { };
            _callback = callback;
        }

        private readonly Action _callback;
        
        protected override void DisposeInternal()
        {
            _callback.Invoke();
        }
    }
}
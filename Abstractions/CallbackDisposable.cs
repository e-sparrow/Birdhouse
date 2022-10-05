using System;

namespace Birdhouse.Abstractions
{
    public class CallbackDisposable : DisposableBase
    {
        public CallbackDisposable(Action callback)
        {
            _callback = callback;
        }

        private readonly Action _callback;
        
        protected override void DisposeInternal()
        {
            _callback.Invoke();
        }
    }
}
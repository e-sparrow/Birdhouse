using System;

namespace Birdhouse.Abstractions.Disposables
{
    public class CallbackDisposable : IDisposable
    {
        public CallbackDisposable(Action callback = null)
        {
            callback ??= () => { };
            _callback = callback;
        }

        private readonly Action _callback;
        
        public void Dispose()
        {
            _callback.Invoke();
        }
    }
}
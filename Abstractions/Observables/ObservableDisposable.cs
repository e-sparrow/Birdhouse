using System;

namespace Birdhouse.Abstractions.Observables
{
    public class ObservableDisposable 
        : IObservableDisposable
    {
        public ObservableDisposable(IDisposable disposable)
        {
            _disposable = disposable;
        }

        public event Action OnDispose = () => { };
        
        private readonly IDisposable _disposable;
        
        public void Dispose()
        {
            _disposable.Dispose();
            OnDispose.Invoke();
        }
    }
}
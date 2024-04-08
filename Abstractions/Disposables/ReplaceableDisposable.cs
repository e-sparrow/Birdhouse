using System;
using Birdhouse.Abstractions.Disposables.Interfaces;

namespace Birdhouse.Abstractions.Disposables
{
    public class ReplaceableDisposable : IReplaceableDisposable
    {
        public ReplaceableDisposable(IDisposable disposable = null)
        {
            disposable ??= new DisposableDummy();
            
            _disposable = disposable;
        }
        
        private IDisposable _disposable;
        
        public void Replace(IDisposable disposable)
        {
            _disposable = disposable;
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
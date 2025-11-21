using System;
using Birdhouse.Abstractions.Disposables;

namespace Birdhouse.Abstractions.Disposables
{
    public interface IReplaceableDisposable 
        : IDisposable
    {
        void Replace(IDisposable other);
    }
    
    public class ReplaceableDisposable 
        : IReplaceableDisposable
    {
        public ReplaceableDisposable(IDisposable disposable = null)
        {
            disposable ??= new DisposableDummy();
            _disposable = disposable;
        }
        
        private IDisposable _disposable;
        
        public void Replace(IDisposable disposable) => _disposable = disposable;
        public void Dispose() => _disposable.Dispose();
    }
}
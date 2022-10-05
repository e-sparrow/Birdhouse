using System;

namespace Birdhouse.Abstractions
{
    public abstract class DisposableBase : IDisposable
    {
        protected abstract void DisposeInternal();
        
        public void Dispose()
        {
            DisposeInternal();
        }
    }
}
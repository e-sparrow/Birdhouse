using Birdhouse.Abstractions.Interfaces;

namespace Birdhouse.Abstractions
{
    public abstract class RenewableBase : IRenewable
    {
        protected abstract void SetPausedInternal(bool isPaused);
        
        public void SetPaused(bool isPaused)
        {
            SetPausedInternal(isPaused);
            IsPaused = isPaused;
        }

        public bool IsPaused
        {
            get;
            private set;
        }
    }
}
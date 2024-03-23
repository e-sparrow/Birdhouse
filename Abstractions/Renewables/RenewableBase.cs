using Birdhouse.Abstractions.Renewables.Interfaces;

namespace Birdhouse.Abstractions.Renewables
{
    public abstract class RenewableBase 
        : IRenewable
    {
        private bool _isPaused = false;
        
        protected abstract void SetPausedInternal(bool isPaused);

        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                _isPaused = value;
                SetPausedInternal(_isPaused);
            }
        }
    }
}
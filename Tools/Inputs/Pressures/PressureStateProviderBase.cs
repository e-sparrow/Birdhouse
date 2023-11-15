using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public abstract class PressureStateProviderBase<TKey> 
        : IPressureStateProvider<TKey>
    {
        protected abstract bool IsPressed(TKey key);
        protected abstract bool IsHeld(TKey key);
        protected abstract bool IsReleased(TKey key);
        
        public EPressureState GetPressureState(TKey key)
        {
            if (IsPressed(key))
            {
                return EPressureState.Pressed;
            }

            if (IsHeld(key))
            {
                return EPressureState.Holden;
            }

            if (IsReleased(key))
            {
                return EPressureState.Released;
            }

            return EPressureState.Untouched;
        }
    }
}

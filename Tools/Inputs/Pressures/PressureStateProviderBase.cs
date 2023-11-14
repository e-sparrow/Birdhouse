using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures
{
    public abstract class PressureStateProviderBase<TPressure> : IPressureStateProvider<TPressure>
    {
        protected abstract bool IsPressed(TPressure pressure);
        protected abstract bool IsHeld(TPressure pressure);
        protected abstract bool IsReleased(TPressure pressure);
        
        public EPressureState GetPressureState(TPressure pressure)
        {
            if (IsPressed(pressure))
            {
                return EPressureState.Pressed;
            }

            if (IsHeld(pressure))
            {
                return EPressureState.Holden;
            }

            if (IsReleased(pressure))
            {
                return EPressureState.Released;
            }

            return EPressureState.Untouched;
        }
    }
}

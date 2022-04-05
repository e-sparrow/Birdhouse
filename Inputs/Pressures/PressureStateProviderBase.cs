using ESparrow.Utils.Inputs.Pressures.Enums;
using ESparrow.Utils.Inputs.Pressures.Interfaces;

namespace ESparrow.Utils.Inputs.Pressures
{
    public abstract class PressureStateProviderBase<TPressure> : IPressureStateProvider<TPressure>
    {
        protected abstract bool IsPressed(TPressure pressure);
        protected abstract bool IsHolden(TPressure pressure);
        protected abstract bool IsReleased(TPressure pressure);
        
        public EPressureState GetPressureState(TPressure pressure)
        {
            if (IsPressed(pressure))
                return EPressureState.Pressed;
            if (IsHolden(pressure))
                return EPressureState.Holden;
            if (IsReleased(pressure))
                return EPressureState.Released;

            return EPressureState.Untouched;
        }
    }
}

using ESparrow.Utils.Inputs.Pressures.Enums;
using ESparrow.Utils.Inputs.Pressures.Interfaces;

namespace ESparrow.Utils.Inputs.Pressures
{
    public class PressureInfo<TPressure> : IPressureInfo<TPressure>
    {
        public PressureInfo(TPressure pressure, EPressureState state)
        {
            Pressure = pressure;
            State = state;
        }

        public TPressure Pressure
        {
            get;
        }

        public EPressureState State
        {
            get;
        }
    }
}
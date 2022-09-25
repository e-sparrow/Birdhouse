using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Tools.Inputs.Pressures
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
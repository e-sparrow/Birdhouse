using Birdhouse.Tools.Inputs.Pressures;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public static class PressureHelper
    {
        public static IPressureActivation<IPressureInfo<TPressure>, TPressure> CreateActivation<TPressure>
            (TPressure pressure, EPressureState state, float time)
        {
            var info = new PressureInfo<TPressure>(pressure, state);
            
            var activation = new PressureActivation<PressureInfo<TPressure>, TPressure>(info, time);
            return activation;
        }
    }
}
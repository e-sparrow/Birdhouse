using ESparrow.Utils.Inputs.Pressures;
using ESparrow.Utils.Inputs.Pressures.Enums;
using ESparrow.Utils.Inputs.Pressures.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Helpers
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
using Birdhouse.Tools;
using UnityEngine;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public class FloatToInterpolatorAdapter : ToInterpolatorAdapterBase<float>
    {
        public override float Interpolate(float from, float to, float progress)
        {
            return from + (to - from) * progress;
        }
    }
}

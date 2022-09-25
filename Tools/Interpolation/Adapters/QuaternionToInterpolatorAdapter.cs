using Birdhouse.Tools;
using UnityEngine;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public class QuaternionToInterpolatorAdapter : ToInterpolatorAdapterBase<Quaternion>
    {
        public override Quaternion Interpolate(Quaternion from, Quaternion to, float progress)
        {
            return Quaternion.Lerp(from, to, progress);
        }
    }
}

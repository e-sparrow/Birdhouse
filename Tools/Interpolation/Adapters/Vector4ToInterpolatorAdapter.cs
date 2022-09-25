using Birdhouse.Tools;
using UnityEngine;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public class Vector4ToInterpolatorAdapter : ToInterpolatorAdapterBase<Vector4>
    {
        public override Vector4 Interpolate(Vector4 from, Vector4 to, float progress)
        {
            return Vector4.Lerp(from, to, progress);
        }
    }
}
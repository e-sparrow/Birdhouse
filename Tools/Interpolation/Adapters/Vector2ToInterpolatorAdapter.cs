using Birdhouse.Tools;
using UnityEngine;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public class Vector2ToInterpolatorAdapter : ToInterpolatorAdapterBase<Vector2>
    {
        public override Vector2 Interpolate(Vector2 from, Vector2 to, float progress)
        {
            return Vector2.Lerp(from, to, progress);
        }
    }
}

using Birdhouse.Tools;
using UnityEngine;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public class ColorToInterpolatorAdapter : ToInterpolatorAdapterBase<Color>
    {
        public override Color Interpolate(Color from, Color to, float progress)
        {
            return Color.Lerp(from, to, progress);
        }
    }
}

using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class ColorToInterpolatorAdapter : ToInterpolatorAdapterBase<Color>
    {
        public override Color Interpolate(Color from, Color to, float progress)
        {
            return Color.Lerp(from, to, progress);
        }
    }
}

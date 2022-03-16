using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class FloatToInterpolatorAdapter : ToInterpolatorAdapterBase<float>
    {
        public override float Interpolate(float from, float to, float progress)
        {
            return from + (to - from) * progress;
        }
    }
}

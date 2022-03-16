using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class Vector4ToInterpolatorAdapter : ToInterpolatorAdapterBase<Vector4>
    {
        public override Vector4 Interpolate(Vector4 from, Vector4 to, float progress)
        {
            return Vector4.Lerp(from, to, progress);
        }
    }
}
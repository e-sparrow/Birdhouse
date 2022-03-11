using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class Vector3ToInterpolatorAdapter : ToInterpolatorAdapterBase<Vector3>
    {
        public override Vector3 Interpolate(Vector3 from, Vector3 to, float progress)
        {
            return Vector3.Lerp(from, to, progress);
        }
    }
}

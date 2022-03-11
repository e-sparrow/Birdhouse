using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class QuaternionToInterpolatorAdapter : ToInterpolatorAdapterBase<Quaternion>
    {
        public override Quaternion Interpolate(Quaternion from, Quaternion to, float progress)
        {
            return Quaternion.Lerp(from, to, progress);
        }
    }
}

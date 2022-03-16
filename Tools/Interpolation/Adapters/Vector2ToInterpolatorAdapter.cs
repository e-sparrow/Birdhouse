using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class Vector2ToInterpolatorAdapter : ToInterpolatorAdapterBase<Vector2>
    {
        public override Vector2 Interpolate(Vector2 from, Vector2 to, float progress)
        {
            return Vector2.Lerp(from, to, progress);
        }
    }
}

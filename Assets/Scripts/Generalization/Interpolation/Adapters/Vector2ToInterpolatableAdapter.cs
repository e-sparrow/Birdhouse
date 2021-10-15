using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class Vector2ToInterpolatableAdapter : ToInterpolatableAdapterBase<Vector2>
    {
        public Vector2ToInterpolatableAdapter(Reference<Vector2> value) : base(value)
        {

        }

        public override void Interpolate(Vector2 from, Vector2 to, float progress)
        {
            Value = Vector2.Lerp(from, to, progress);
        }
    }
}

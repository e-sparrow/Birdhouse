using UnityEngine;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class Vector2ToInterpolatableAdapter : ToInterpolatableAdapterBase<Vector2>
    {
        public Vector2ToInterpolatableAdapter(Reference<Vector2> value) : base(value)
        {

        }

        public override void Interpolate(Vector2 from, Vector2 to, float t)
        {
            Value = Vector2.Lerp(from, to, t);
        }
    }
}

using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class Vector4ToInterpolatableAdapter : ToInterpolatableAdapterBase<Vector4>
    {
        public Vector4ToInterpolatableAdapter(Reference<Vector4> value) : base(value)
        {

        }

        public override void Interpolate(Vector4 from, Vector4 to, float progress)
        {
            Value = Vector4.Lerp(from, to, progress);
        }
    }
}
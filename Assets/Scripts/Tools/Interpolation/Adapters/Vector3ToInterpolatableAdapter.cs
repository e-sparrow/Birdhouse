using UnityEngine;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class Vector3ToInterpolatableAdapter : ToInterpolatableAdapterBase<Vector3>
    {
        public Vector3ToInterpolatableAdapter(Reference<Vector3> value) : base(value)
        {

        }

        public override void Interpolate(Vector3 from, Vector3 to, float t)
        {
            Value = Vector3.Lerp(from, to, t);
        }
    }
}

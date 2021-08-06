using UnityEngine;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class QuaternionToInterpolatableAdapter : ToInterpolatableAdapterBase<Quaternion>
    {
        public QuaternionToInterpolatableAdapter(Reference<Quaternion> value) : base(value)
        {

        }

        public override void Interpolate(Quaternion from, Quaternion to, float t)
        {
            Value = Quaternion.Lerp(from, to, t);
        }
    }
}

using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class QuaternionToInterpolatableAdapter : ToInterpolatableAdapterBase<Quaternion>
    {
        public QuaternionToInterpolatableAdapter(Reference<Quaternion> value) : base(value)
        {

        }

        public override void Interpolate(Quaternion from, Quaternion to, float progress)
        {
            Value = Quaternion.Lerp(from, to, progress);
        }
    }
}

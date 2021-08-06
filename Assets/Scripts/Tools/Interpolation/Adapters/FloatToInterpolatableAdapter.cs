using UnityEngine;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class FloatToInterpolatableAdapter : ToInterpolatableAdapterBase<float>
    {
        public FloatToInterpolatableAdapter(Reference<float> value) : base(value)
        {

        }

        public override void Interpolate(float from, float to, float t)
        {
            Value = Mathf.Lerp(from, to, t);
        }
    }
}

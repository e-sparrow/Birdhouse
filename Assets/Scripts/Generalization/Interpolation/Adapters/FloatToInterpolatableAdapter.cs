using ESparrow.Utils.Tools;
using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class FloatToInterpolatableAdapter : ToInterpolatableAdapterBase<float>
    {
        public FloatToInterpolatableAdapter(Reference<float> value) : base(value)
        {

        }

        public override void Interpolate(float from, float to, float progress)
        {
            Value = Mathf.Lerp(from, to, progress);
        }
    }
}

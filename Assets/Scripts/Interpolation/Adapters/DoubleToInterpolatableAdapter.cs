using UnityEngine;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Interpolation.Adapters
{
    public class DoubleToInterpolatableAdapter : ToInterpolatableAdapterBase<double>
    {
        public DoubleToInterpolatableAdapter(Reference<double> value) : base(value)
        {

        }

        public override void Interpolate(double from, double to, float t)
        {
            Value = (double) Mathf.Lerp((float) from, (float) to, t);
        }
    }
}

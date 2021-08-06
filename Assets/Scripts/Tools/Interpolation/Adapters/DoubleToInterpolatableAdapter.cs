using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class DoubleToInterpolatableAdapter : ToInterpolatableAdapterBase<double>
    {
        public DoubleToInterpolatableAdapter(Reference<double> value) : base(value)
        {

        }

        public override void Interpolate(double from, double to, float t)
        {
            Value = from + (to - from) * t;
        }
    }
}

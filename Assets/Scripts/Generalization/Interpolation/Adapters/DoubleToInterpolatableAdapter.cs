using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Generalization.Interpolation.Adapters
{
    public class DoubleToInterpolatableAdapter : ToInterpolatableAdapterBase<double>
    {
        public DoubleToInterpolatableAdapter(Reference<double> value) : base(value)
        {

        }

        public override void Interpolate(double from, double to, float progress)
        {
            Value = from + (to - from) * progress;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Double;
    }
}

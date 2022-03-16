using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Tools;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public class DoubleToInterpolatorAdapter : ToInterpolatorAdapterBase<double>
    {
        public override double Interpolate(double from, double to, float progress)
        {
            return from + (to - from) * progress;
        }
    }
}

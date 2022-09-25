using Birdhouse.Tools;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public class DoubleToInterpolatorAdapter : ToInterpolatorAdapterBase<double>
    {
        public override double Interpolate(double from, double to, float progress)
        {
            return from + (to - from) * progress;
        }
    }
}

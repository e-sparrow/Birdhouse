using Birdhouse.Tools.Interpolation.Interfaces;

namespace Birdhouse.Tools.Interpolation.Adapters
{
    public abstract class ToInterpolatorAdapterBase<T> : IInterpolator<T>
    {
        public abstract T Interpolate(T from, T to, float progress);
    }
}

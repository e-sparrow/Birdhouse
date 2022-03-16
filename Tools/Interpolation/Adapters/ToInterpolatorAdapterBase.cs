using ESparrow.Utils.Tools.Interpolation.Interfaces;

namespace ESparrow.Utils.Tools.Interpolation.Adapters
{
    public abstract class ToInterpolatorAdapterBase<T> : IInterpolator<T>
    {
        public abstract T Interpolate(T from, T to, float progress);
    }
}

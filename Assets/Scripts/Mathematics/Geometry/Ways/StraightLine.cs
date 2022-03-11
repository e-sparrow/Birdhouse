using System;
using ESparrow.Utils.Tools.Interpolation.Interfaces;

namespace ESparrow.Utils.Mathematics.Ways
{
    [Serializable]
    public class StraightLine<T> : WayBase<T>
    {
        public StraightLine(IInterpolator<T> interpolator, T start, T end) : base(CreateFunc(interpolator, start, end))
        {
            
        }

        private static Func<float, T> CreateFunc(IInterpolator<T> interpolator, T start, T end)
        {
            return Interpolate;

            T Interpolate(float progress)
            {
                return interpolator.Interpolate(start, end, progress);
            }
        }
    }
}

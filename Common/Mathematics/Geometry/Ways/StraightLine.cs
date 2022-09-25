using System;
using Birdhouse.Tools.Interpolation.Interfaces;

namespace Birdhouse.Common.Mathematics.Geometry.Ways
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

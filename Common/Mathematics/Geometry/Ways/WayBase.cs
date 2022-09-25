using System;
using Birdhouse.Common.Mathematics.Geometry.Ways.Interfaces;

namespace Birdhouse.Common.Mathematics.Geometry.Ways
{
    public abstract class WayBase<T> : IWay<T>
    {
        protected WayBase(Func<float, T> func)
        {
            _func = func;
        }

        private readonly Func<float, T> _func;

        public T Evaluate(float progress)
        {
            return _func.Invoke(progress);
        }
    }
}
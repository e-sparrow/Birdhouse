using UnityEngine;

namespace Birdhouse.Common.Mathematics.Geometry.Ways.Interfaces
{
    public interface IWay<out T>
    {
        /// <summary>
        /// Gets a point on the way by path share in argument.
        /// </summary>
        /// <param name="progress">Path share</param>
        /// <returns></returns>
        T Evaluate(float progress);
    }

    public interface IWay : IWay<Vector3>
    {
        
    }
}

using UnityEngine;

namespace Birdhouse.Common.Mathematics
{
    public static class TrigonometryProvider
    {
        /// <summary>
        /// Returns sin between two values.
        /// F.e. default sin is sin between -1 and 1.
        /// </summary>
        /// <param name="min">Min sin value</param>
        /// <param name="max">Max sin value</param>
        /// <param name="progress">Interpolate t variable</param>
        /// <returns>Sin between specified values</returns>
        public static float SinBetween(float min, float max, float progress)
        {
            return Mathf.Lerp(min, max, (Mathf.Sin(progress) + 1) / 2);
        }

        /// <summary>
        /// Returns sin between 0 and 1.
        /// </summary>
        /// <param name="progress">Interpolate t variable</param>
        /// <returns>Sin between 0 and 1</returns>
        public static float SinFromZeroToOne(float progress)
        {
            return SinBetween(0f, 1f, progress); 
        }
    }
}

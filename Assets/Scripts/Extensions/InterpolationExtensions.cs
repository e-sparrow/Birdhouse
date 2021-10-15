using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using ESparrow.Utils.Tools;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Generalization.Interpolation.Adapters;
using ESparrow.Utils.Generalization.Interpolation.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class InterpolationExtensions
    {
        /// <summary>
        /// Converts decimal to interpolatable interface.
        /// </summary>
        /// <param name="value">Reference to double</param>
        /// <returns>Reference to double as interpolatable interface</returns>
        public static IInteropolatable<double> AsInterpolatable(this Reference<double> value)
        {
            return new DoubleToInterpolatableAdapter(value);
        }

        /// <summary>
        /// Converts float to interpolatable interface.
        /// </summary>
        /// <param name="value">Reference to float</param>
        /// <returns>Reference to float as interpolatable interface</returns>
        public static IInteropolatable<float> AsInterpolatable(this Reference<float> value)
        {
            return new FloatToInterpolatableAdapter(value);
        }

        /// <summary>
        /// Converts Vector2 to interpolatable interface.
        /// </summary>
        /// <param name="value">Reference to Vector2</param>
        /// <returns>Reference to Vector2 as interpolatable interface</returns>
        public static IInteropolatable<Vector2> AsInterpolatable(this Reference<Vector2> value)
        {
            return new Vector2ToInterpolatableAdapter(value);
        }

        /// <summary>
        /// Converts Vector3 to interpolatable interface.
        /// </summary>
        /// <param name="value">Reference to Vector3</param>
        /// <returns>Reference to Vector3 as interpolatable interface</returns>
        public static IInteropolatable<Vector3> AsInterpolatable(this Reference<Vector3> value)
        {
            return new Vector3ToInterpolatableAdapter(value);
        }

        /// <summary>
        /// Converts Quaternion to interpolatable interface.
        /// </summary>
        /// <param name="value">Reference to Quaternion</param>
        /// <returns>Reference to Quaternion as interpolatable interface</returns>
        public static IInteropolatable<Quaternion> AsInterpolatable(this Reference<Quaternion> value)
        {
            return new QuaternionToInterpolatableAdapter(value);
        }

        /// <summary>
        /// Converts Color to interpolatable interface.
        /// </summary>
        /// <param name="value">Reference to Color</param>
        /// <returns>Reference to Color as interpolatable interface</returns>
        public static IInteropolatable<Color> AsInterpolatable(this Reference<Color> value)
        {
            return new ColorToInterpolatableAdapter(value);
        }

        /// <summary>
        /// Creates routine which interpolate specified interpolatable.
        /// </summary>
        /// <param name="self">Self interpolatable</param>
        /// <param name="target">Target value to interpolate</param>
        /// <param name="time">Time of interpolation</param>
        /// <param name="curve">Curve for not linear interpolation</param>
        /// <typeparam name="T">Type of interpolatable</typeparam>
        /// <returns>Routine to interpolation</returns>
        public static IEnumerator InterpolateFor<T>
        (
            this IInteropolatable<T> self, 
            T target, 
            float time, 
            AnimationCurve curve = default
        )
        {
            var temp = self.Value;

            yield return CoroutinesHelper.Graduate(SetProgress, time, false, curve);

            void SetProgress(float progress)
            {
                self.Interpolate(temp, target, progress);
            }
        }

        /// <summary>
        /// Starts routine which interpolate specified interpolatable.
        /// </summary>
        /// <param name="monoBehaviour">Behaviour which will start the routine</param>
        /// <param name="self">Self interpolatable interface</param>
        /// <param name="target">Target value to interpolate</param>
        /// <param name="time">Time to interpolate</param>
        /// <param name="curve">Curve for not linear interpolation</param>
        /// <typeparam name="T">Type of interpolatable</typeparam>
        public static void InterpolateFor<T>
        (
            this MonoBehaviour monoBehaviour,
            IInteropolatable<T> self,
            T target,
            float time,
            AnimationCurve curve = default
        )
        {
            monoBehaviour.StartCoroutine(self.InterpolateFor(target, time, curve));
        }

        /// <summary>
        /// Starts routine which interpolate specified interpolatable async.
        /// </summary>
        /// <param name="monoBehaviour">Behaviour which will start the routine</param>
        /// <param name="self">Self interpolatable interface</param>
        /// <param name="target">Target value to interpolate</param>
        /// <param name="time">Time to interpolate</param>
        /// <param name="curve">Curve for not linear interpolation</param>
        /// <typeparam name="T">Type of interpolatable</typeparam>
        public static async Task InterpolateForAsync<T>
        (
            this MonoBehaviour monoBehaviour,
            IInteropolatable<T> self,
            T target,
            float time,
            AnimationCurve curve = default
        )
        {
            await monoBehaviour.StartCoroutineAsync(self.InterpolateFor(target, time, curve));
        }

        /// <summary>
        /// Starts routine which interpolate specified interpolatable async.
        /// </summary>
        /// <param name="self">Self interpolatable interface</param>
        /// <param name="target">Target value to interpolate</param>
        /// <param name="time">Time to interpolate</param>
        /// <param name="curve">Curve for not linear interpolation</param>
        /// <typeparam name="T">Type of interpolatable</typeparam>
        public static async Task InterpolateForAsync<T>
        (
            this IInteropolatable<T> self,
            T target,
            float time,
            AnimationCurve curve = default
        )
        {
            await self.InterpolateFor(target, time, curve).StartAsync();
        }
    }
}
    
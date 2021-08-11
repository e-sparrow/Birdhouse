using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using ESparrow.Utils.Tools;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Interpolation.Adapters;
using ESparrow.Utils.Tools.Interpolation.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class InterpolationExtensions
    {
        public static IInteropolatable<double> AsInterpolatable(this Reference<double> value)
        {
            return new DoubleToInterpolatableAdapter(value);
        }

        public static IInteropolatable<float> AsInterpolatable(this Reference<float> value)
        {
            return new FloatToInterpolatableAdapter(value);
        }

        public static IInteropolatable<Vector2> AsInterpolatable(this Reference<Vector2> value)
        {
            return new Vector2ToInterpolatableAdapter(value);
        }

        public static IInteropolatable<Vector3> AsInterpolatable(this Reference<Vector3> value)
        {
            return new Vector3ToInterpolatableAdapter(value);
        }

        public static IInteropolatable<Quaternion> AsInterpolatable(this Reference<Quaternion> value)
        {
            return new QuaternionToInterpolatableAdapter(value);
        }

        public static IInteropolatable<Color> AsInterpolatable(this Reference<Color> value)
        {
            return new ColorToInterpolatableAdapter(value);
        }

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
    
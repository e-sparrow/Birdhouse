using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Collections.Generic;
using ESparrow.Utils.Tools.Easing;
using ESparrow.Utils.Tools.Easing.Interfaces;
using ESparrow.Utils.Tools.Graduating;
using ESparrow.Utils.Tools.Graduating.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Helpers
{
    public static class CoroutinesHelper
    {
        private static readonly IGradual Gradual = new Gradual();
        
        public static IEnumerator Graduate(IGradualSettings settings)
        {
            yield return Gradual.Graduate(settings);
        }

        public static IEnumerator Graduate(Action<float> action, float duration, IEase ease = null)
        {
            ease ??= new Ease();
            var settings = new GradualSettings(action, duration, ease);
            return Graduate(settings);
        }

        public static IEnumerator Graduate(Action<float> action, ITweeningSettings settings)
        {
            return Graduate(action, (float) settings.Duration.TotalSeconds, settings.Ease);
        }

        public static IEnumerator ExecuteConsistently(IEnumerable<IEnumerator> coroutines, float cooldown = 0f)
        {
            foreach (var coroutine in coroutines)
            {
                yield return coroutine;
                yield return new WaitForSeconds(cooldown);
            }
        }

        public static IEnumerator ExecuteConsistently(float cooldown = 0f, params IEnumerator[] coroutines)
        {
            yield return ExecuteConsistently(coroutines, cooldown);
        }

        public static IEnumerator CoroutineWithCallback(IEnumerator coroutine, Action callback)
        {
            yield return coroutine;
            callback.Invoke();
        }

        /// <summary>
        /// Повторяет одно и то же действие count раз через промежуток duration.
        /// </summary>
        public static IEnumerator Repeat(Action action, int count, float duration)
        {
            for (int i = 0; i < count; i++)
            {
                action.Invoke();
                yield return new WaitForSeconds(duration);
            }
        }

        /// <summary>
        /// Воспроизводит метод foreach с 
        /// </summary>
        public static IEnumerator ForeachWithStep<T>(IEnumerable<T> collection, Action<T> action, float step, Action callback = default)
        {
            foreach (var element in collection)
            {
                action.Invoke(element);
                yield return new WaitForSeconds(step);
            }

            callback?.Invoke();
        }

        public static IEnumerator Jump(Vector3 from, Vector3 to, Action<Vector3> action, float duration, float height, IEase ease)
        {
            var settings = new GradualSettings(SetProgress, duration, ease);
            yield return Graduate(settings);

            void SetProgress(float progress)
            {
                var position = Vector2.Lerp(from, to, progress);

                var currentHeight = Mathf.Lerp(from.y, to.y, progress);
                var currentJumpHeight = Mathf.Sin(progress * Mathf.PI) * height;

                position.y = currentHeight + currentJumpHeight;

                action.Invoke(position);
            }
        }
    }
}

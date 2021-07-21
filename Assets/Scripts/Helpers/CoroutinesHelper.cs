using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Helpers
{
    public static class CoroutinesHelper
    {
        /// <summary>
        /// Выполняет действие каждый кадр с заданными настройками с аргументом от 0 до 1.
        /// </summary>
        public static IEnumerator Graduate
        (
            Action<float> action,
            float duration,
            bool reverse = false,
            AnimationCurve curve = default
        )
        {
            for (float time = 0f; time < duration; time += Time.deltaTime)
            {
                float ratio = time / duration;
                ratio = reverse ? 1f - ratio : ratio;

                float progress = curve == default ? ratio : curve.Evaluate(ratio);

                action.Invoke(progress);

                yield return null;
            }

            action.Invoke(curve == default ? reverse ? 0f : 1f : curve.Evaluate(reverse ? 0f : 1f));
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
    }
}

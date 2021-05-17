using System;
using System.Collections;
using UnityEngine;

namespace ESparrow.Utils
{
    public static class Coroutines
    {
        /// <summary>
        /// Выполняет действие каждый кадр с заданными настройками с аргументом от 0 до 1.
        /// </summary>
        public static IEnumerator Graduate
        (
            Action<float> action, 
            float duration, 
            bool reverse = false, 
            AnimationCurve curve = default,
            Action callback = default
        )
        {
            float time = 0f;
            while (time < duration)
            {
                float ratio = time / duration;
                ratio = reverse ? 1f - ratio : ratio;

                float progress = curve == default ? ratio : curve.Evaluate(ratio);

                action.Invoke(progress);

                time += Time.deltaTime;
                yield return null;
            }

            action.Invoke(curve == default ? reverse ? 0f : 1f : curve.Evaluate(reverse ? 0f : 1f));
            callback?.Invoke();
        }

        /// <summary>
        /// Повторяет одно и то же действие count раз через промежуток duration.
        /// </summary>
        public static IEnumerator Repeat(Action action, int count, float duration)
        {
            for (int i = 0; i < count; i++)
            {
                action.Invoke();
                yield return duration;
            }
        }
    }
}

using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using ESparrow.Utils.Managers;

namespace ESparrow.Utils.Extensions
{
    public static class CoroutinesExtensions
    {
        public static void Start(this IEnumerator routine, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(routine);
        }

        public static async Task StartAsync(this IEnumerator routine, MonoBehaviour monoBehaviour)
        {
            await monoBehaviour.StartCoroutineAsync(routine);
        }

        public static void Start(this IEnumerator routine)
        {
            GlobalManager.Instance.StartCoroutine(routine);
        }

        public static async Task StartAsync(this IEnumerator routine)
        {
            await GlobalManager.Instance.StartCoroutineAsync(routine);
        }

        public static IEnumerator ContinueWith(this IEnumerator routine, IEnumerator next)
        {
            yield return routine;
            yield return next;
        }
        
        public static IEnumerator After(this IEnumerator routine, IEnumerator before)
        {
            yield return before;
            yield return routine;
        }

        public static IEnumerator Repeat(this IEnumerator routine, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return routine;
            }
        }
    }
}

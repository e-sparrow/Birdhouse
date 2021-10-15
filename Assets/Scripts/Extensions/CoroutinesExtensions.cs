using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using UnityEngine;
using ESparrow.Utils.Managers;

namespace ESparrow.Utils.Extensions
{
    public static class CoroutinesExtensions
    {
        /// <summary>
        /// Starts the routine from specified MonoBehaviour.
        /// </summary>
        /// <param name="routine">Routine to start</param>
        /// <param name="monoBehaviour">MonoBehaviour which will start the routine</param>
        public static void Start(this IEnumerator routine, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(routine);
        }

        /// <summary>
        /// Starts the routine from specified MonoBehaviour async.
        /// </summary>
        /// <param name="routine">Routine to start</param>
        /// <param name="monoBehaviour">MonoBehaviour which will start the routine</param>
        /// <param name="token">Token to cancel the routine</param>
        public static async Task StartAsync
        (
            this IEnumerator routine, 
            MonoBehaviour monoBehaviour, 
            CancellationToken token = new CancellationToken()
        )
        {
            await monoBehaviour.StartCoroutineAsync(routine, token);
        }

        /// <summary>
        /// Starts the routine from GlobalManager singleton.
        /// </summary>
        /// <param name="routine">Routine to start</param>
        public static void Start(this IEnumerator routine)
        {
            GlobalManager.Instance.StartCoroutine(routine);
        }

        /// <summary>
        /// Starts the routine from GlobalManager singleton async.
        /// </summary>
        /// <param name="routine">Routine to start</param>
        /// <param name="token">Token to cancel the routine</param>
        public static async Task StartAsync(this IEnumerator routine, CancellationToken token = new CancellationToken())
        {
            await GlobalManager.Instance.StartCoroutineAsync(routine, token);
        }

        /// <summary>
        /// Starts the "next" routine after the routine before the dot.
        /// </summary>
        /// <param name="routine">Routine before the dot</param>
        /// <param name="next">Next routine, starts after previous one</param>
        /// <returns>New routine with "routine" before "next"</returns>
        public static IEnumerator ContinueWith(this IEnumerator routine, IEnumerator next)
        {
            yield return routine;
            yield return next;
        }
        
        /// <summary>
        /// Starts the "routine" after the routine before the dot.
        /// </summary>
        /// <param name="routine">Routine before the dot</param>
        /// <param name="before">Routine to start before previous one</param>
        /// <returns>New routine with "routine" after "before"</returns>
        public static IEnumerator After(this IEnumerator routine, IEnumerator before)
        {
            yield return before;
            yield return routine;
        }

        /// <summary>
        /// Repeats one routine specified count of times.
        /// </summary>
        /// <param name="routine">Routine to repeat</param>
        /// <param name="count">Count of times</param>
        /// <returns>New routine which repeats it</returns>
        public static IEnumerator Repeat(this IEnumerator routine, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return routine;
            }
        }
    }
}

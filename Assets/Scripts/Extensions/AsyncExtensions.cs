using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Extensions
{
    public static class AsyncExtensions
    {
        public static async Task StartCoroutineAsync
        (
            this MonoBehaviour monoBehaviour,
            IEnumerator coroutine,
            CancellationToken token = new CancellationToken()
        )
        {
            bool ended = false;

            var enumerator = CoroutinesHelper.CoroutineWithCallback(coroutine, () => ended = true);
            var routine = monoBehaviour.StartCoroutine(enumerator);

            while (!ended)
            {
                if (token.IsCancellationRequested)
                {
                    monoBehaviour.StopCoroutine(routine);
                    return;
                }

                await Task.Yield();
            }
        }

        public static async Task PlayAnimationAsync
        (
            this Animation animation, 
            CancellationToken token = new CancellationToken()
        )
        {
            animation.Play();

            while (animation.isPlaying)
            {
                if (token.IsCancellationRequested)
                {
                    animation.Stop();
                    return;
                }

                await Task.Yield();
            }
        }

        public static async Task PlayAnimationAsync
        (
            this Animator animator,
            string animationName,
            int layer = 0,
            CancellationToken token = new CancellationToken()
        )
        {
            animator.Play(animationName, layer);

            while (animator.GetCurrentAnimatorStateInfo(layer).IsName(animationName))
            {
                if (token.IsCancellationRequested)
                {
                    animator.StopPlayback();
                }

                await Task.Yield(); 
            }
        }
    }
}

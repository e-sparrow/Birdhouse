using System;
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

            await AsyncHelper.WaitUntil(() => ended, token);
        }

        public static async Task PlayAnimationAsync
        (
            this Animation animation, 
            CancellationToken token = new CancellationToken()
        )
        {
            animation.Play();

            await AsyncHelper.WaitWhile(() => animation.isPlaying, token);
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

            await AsyncHelper.WaitWhile(() => animator.GetCurrentAnimatorStateInfo(layer).IsName(animationName), token);
        }

        public static async Task WaitAction(this Action action)
        {
            bool invoked = false;
            action += () => invoked = true;

            await AsyncHelper.WaitUntil(() => invoked);
        }
    }
}

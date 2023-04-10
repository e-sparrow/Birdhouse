using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Common.Helpers;
using UnityEngine;

namespace Birdhouse.Common.Extensions
{
    public static class AsyncExtensions
    {
        /// <summary>
        /// Starts routine async from MonoBehaviour in argument.
        /// </summary>
        /// <param name="monoBehaviour">Object which will run routine</param>
        /// <param name="coroutine">Routine</param>
        /// <param name="token">Cancellation token to cancel the routine</param>
        public static async Task StartCoroutineAsync
        (
            this MonoBehaviour monoBehaviour,
            IEnumerator coroutine,
            CancellationToken token = new CancellationToken()
        )
        {
            bool ended = false;

            var enumerator = CoroutinesHelper.CoroutineWithCallback(coroutine, () => ended = true);
            monoBehaviour.StartCoroutine(enumerator);

            await AsyncHelper.WaitUntil(() => ended, token);
        }

        /// <summary>
        /// Plays animation in the argument async and can stop it by token.
        /// </summary>
        /// <param name="animation">Animation to play</param>
        /// <param name="token">Token to stop animation</param>
        public static async Task PlayAnimationAsync
        (
            this Animation animation, 
            CancellationToken token = new CancellationToken()
        )
        {
            animation.Play();

            await AsyncHelper.WaitWhile(() => animation.isPlaying, token);
        }

        /// <summary>
        /// Plays animation async with specified layer and name.
        /// </summary>
        /// <param name="animator">Animator which will play the animation</param>
        /// <param name="animationName">Name of animation</param>
        /// <param name="layer">Layer of animation</param>
        /// <param name="token">Token to stop animation</param>
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

        public static T Sync<T>(this Func<Task<T>> self)
        {
            var task = Task.Run(self);
            var awaiter = task.GetAwaiter();

            var result = awaiter.GetResult();
            return result;
        }
        
        public static T Sync<T>(this Task<T> task)
        {
            var result = task
                .AsFunc()
                .Sync();
            
            return result;
        }

        public static void Sync(this Func<Task> self)
        {
            var task = Task.Run(self);
            var awaiter = task.GetAwaiter();

            awaiter.GetResult();
        }

        public static void Sync(this Task task)
        {
            task
                .AsFunc()
                .Sync();
        }
    }
}

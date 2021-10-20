using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Generic;

namespace ESparrow.Utils.Helpers
{
    public static class AsyncHelper
    {
        /// <summary>
        /// Awaits while specified function returns true.
        /// </summary>
        /// <param name="func">Specified function </param>
        /// <param name="token">Token to cancel task</param>
        /// <param name="onCancellationRequested">Callback which invokes when token is performs cancellation</param>
        public static async Task WaitWhile
        (
            Func<bool> func, 
            CancellationToken token = new CancellationToken(), 
            Action onCancellationRequested = default
        )
        {
            if (onCancellationRequested == default) onCancellationRequested = () => { };

            while (func.Invoke())
            {
                if (token.IsCancellationRequested)
                {
                    onCancellationRequested.Invoke();
                    return;
                }

                await Task.Delay(100, token);
            }
        }

        /// <summary>
        /// Awaits while specified function returns false.
        /// </summary>
        /// <param name="func">Specified function </param>
        /// <param name="token">Token to cancel task</param>
        /// <param name="onCancellationRequested">Callback which invokes when token is performs cancellation</param>
        public static async Task WaitUntil
        (
            Func<bool> func,
            CancellationToken token = new CancellationToken(),
            Action onCancellationRequested = default
        )
        {
            await WaitWhile(() => !func.Invoke(), token, onCancellationRequested);
        }

        /// <summary>
        /// Awaits while subject will be changed.
        /// </summary>
        /// <param name="subject">Subject to observe</param>
        /// <typeparam name="T">Type of subject</typeparam>
        public static async Task WaitForChange<T>(T subject)
        {
            var original = Clone<T>.CreateClone(subject);
            await WaitWhile(() => original.Equals(subject));
        }
    }
}

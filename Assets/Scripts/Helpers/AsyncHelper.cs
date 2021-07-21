using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Generic;

namespace ESparrow.Utils.Helpers
{
    public static class AsyncHelper
    {
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

                await Task.Delay(100);
            }
        }

        public static async Task WaitUntil
        (
            Func<bool> func,
            CancellationToken token = new CancellationToken(),
            Action onCancellationRequested = default
        )
        {
            await WaitWhile(() => !func.Invoke(), token, onCancellationRequested);
        }

        public static async Task WaitForChange<T>(T subject)
        {
            var original = Clone<T>.CreateClone(subject);
            await WaitWhile(() => original.Equals(subject));
        }

        public static async Task WaitAction(Action action)
        {
            bool invoked = false;
            action += () => invoked = true;

            await WaitWhile(() => !invoked);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Helpers
{
    public static class AsyncHelper
    {
        public static async Task WaitWhile(Func<bool> func, CancellationToken token = new CancellationToken())
        {
            while (func.Invoke())
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                await Task.Yield();
            }
        }

        public static async Task WaitUntil(Func<bool> func, CancellationToken token = new CancellationToken())
        {
            await WaitWhile(() => !func.Invoke(), token);
        }
    }
}

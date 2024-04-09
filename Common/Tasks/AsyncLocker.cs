using System;
using System.Threading;
using System.Threading.Tasks;

namespace Birdhouse.Common.Tasks
{
    public sealed class AsyncLocker
    {
        public AsyncLocker(int initialCount = 1, int maxCount = 1)
        {
            _semaphore = new SemaphoreSlim(initialCount, maxCount);
        }

        private readonly SemaphoreSlim _semaphore;

        public async Task LockAsync(Func<Task> func)
        {
            var isTaken = false;
            
            try
            {
                do
                {
                    try { }
                    finally
                    {
                        isTaken = await _semaphore.WaitAsync(TimeSpan.FromSeconds(1));
                    }
                }
                
                while (!isTaken);
                
                await func.Invoke();
            }
            finally
            {
                if (isTaken)
                {
                    _semaphore.Release();
                }
            }
        }

        public async Task<T> LockAsync<T>(Func<Task<T>> func)
        {
            var isTaken = false;
            
            try
            {
                do
                {
                    try { }
                    finally
                    {
                        isTaken = await _semaphore.WaitAsync(TimeSpan.FromSeconds(1));
                    }
                }
                
                while (!isTaken);
                
                return await func.Invoke();
            }
            finally
            {
                if (isTaken)
                {
                    _semaphore.Release();
                }
            }
        }
    }
}
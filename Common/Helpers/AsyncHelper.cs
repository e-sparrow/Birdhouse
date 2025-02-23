using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Tools.Easing.Interfaces;
using Birdhouse.Tools.Graduating;
using Birdhouse.Tools.Graduating.Interfaces;

namespace Birdhouse.Common.Helpers
{
    public delegate ref Action ActionRef();
    public delegate ref Action<T> ActionRef<T>();
    public delegate ref Action<T1, T2> ActionRef<T1, T2>();
    public delegate ref Action<T1, T2, T3> ActionRef<T1, T2, T3>();
    
    public static class AsyncHelper
    {
        public static Task AwaitAction(ActionRef self)
        {
            var source = new TaskCompletionSource<bool>();
            
            self.Invoke() += Handle;
            return source.Task;

            void Handle()
            {
                self.Invoke() -= Handle;
                source.SetResult(true);
            }
        }
        
        public static Task<T> AwaitEvent<T>(ActionRef<T> self)
        {
            var source = new TaskCompletionSource<T>();
            
            self.Invoke() += Handle;
            return source.Task;

            void Handle(T value)
            {
                self.Invoke() -= Handle;
                source.SetResult(value);
            }
        }
        
        public static Task<(T1, T2)> AwaitEvent<T1, T2>(ActionRef<T1, T2> self)
        {
            var source = new TaskCompletionSource<(T1, T2)>();
            
            self.Invoke() += Handle;
            return source.Task;

            void Handle(T1 value1, T2 value2)
            {
                self.Invoke() -= Handle;
                source.SetResult((value1, value2));
            }
        }
        
        public static Task<(T1, T2, T3)> AwaitEvent<T1, T2, T3>(ActionRef<T1, T2, T3> self)
        {
            var source = new TaskCompletionSource<(T1, T2, T3)>();
            
            self.Invoke() += Handle;
            return source.Task;

            void Handle(T1 value1, T2 value2, T3 value3)
            {
                self.Invoke() -= Handle;
                source.SetResult((value1, value2, value3));
            }
        }
        
        public static async Task Graduate(IGradualSettings settings, TimeSpan step)
        {
            var gradual = new AsyncGradual(step);
            await gradual.Graduate(settings);
        }

        public static async Task Graduate(IGradualSettings settings, int step)
        {
            await Graduate(settings, TimeSpan.FromMilliseconds(step));
        }

        public static async Task Graduate(Action<float> action, float duration, TimeSpan step, IEase ease = default)
        {
            await Graduate(new GradualSettings(action, TimeSpan.FromSeconds(duration), ease), step);
        }

        public static async Task Graduate(Action<float> action, float duration, int step, IEase ease = default)
        {
            await Graduate(new GradualSettings(action, TimeSpan.FromSeconds(duration), ease), step);
        }
        
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
            var original = CloneHelper<T>.CreateClone(subject);
            await WaitWhile(() => original.Equals(subject));
        }
    }
}

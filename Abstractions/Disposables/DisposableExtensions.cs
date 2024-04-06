using System;
using System.Collections;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Disposables.Interfaces;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Abstractions.Disposables
{
    public static class DisposableExtensions
    {
        public static CompositeDisposable Append(this IDisposable self, IDisposable other)
        {
            var disposables = self
                .ConcatWith(other)
                .AsCollection();

            var result = new CompositeDisposable(disposables);
            return result;
        }

        public static CompositeDisposable OnDispose(this IDisposable self, Action callback)
        {
            var callbackDisposable = new CallbackDisposable(callback);

            var result = self.Append(callbackDisposable);
            return result;
        }

        public static CompositeDisposable OnDispose(this CompositeDisposable self, Action callback)
        {
            var callbackDisposable = new CallbackDisposable(callback);

            var result = self.Append(callbackDisposable);
            return result;
        }

        public static IReplaceableDisposable AsReplaceable(this IDisposable self)
        {
            var result = new ReplaceableDisposable(self);
            return result;
        }

        public static IEnumerator DisposeAfter(this IDisposable self, IEnumerator coroutine)
        {
            yield return coroutine;
            self.Dispose();
        }

        public static async Task DisposeAfter(this IDisposable self, Task task)
        {
            await task;
            self.Dispose();
        }
    }
}
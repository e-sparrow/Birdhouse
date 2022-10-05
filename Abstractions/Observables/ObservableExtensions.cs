using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Observables.Interfaces;

namespace Birdhouse.Abstractions.Observables
{
    public static class ObservableExtensions
    {
        public static IObservableAction AsObservable(this Action self)
        {
            var result = new ObservableAction(self);
            return result;
        }
        
        public static IObservableDisposable AsObservable(this IDisposable self)
        {
            var result = new ObservableDisposable(self);
            return result;
        }

        public static IObservableAction AsObservable(this IObservableDisposable self)
        {
            var result = new ObservableAction(self.Dispose);
            return result;
        }
        
        public static IObservableAction AsObservable(this CancellationToken self)
        {
            var observable = new ObservableAction();

            self.Register(observable.Invoke);
            return observable;
        }

        public static IObservableAction AsObservableAction(this IDisposable self)
        {
            var disposable = new ObservableDisposable(self);
            
            var result = new ObservableAction(disposable.Dispose);
            return result;
        }

        public static async Task Await(this IObservableAction self)
        {
            var source = new TaskCompletionSource<bool>();
            self.OnInvoke += Perform;

            await source.Task;

            void Perform()
            {
                self.OnInvoke -= Perform;
                source.SetResult(true);
            }
        }

        public static void AppendCallback(this IObservableAction self, Action action)
        {
            self.OnInvoke += Invoke;

            void Invoke()
            {
                self.OnInvoke -= Invoke;
                action.Invoke();
            }
        }
    }
}
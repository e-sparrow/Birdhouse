using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Education.Patterns.Listening.Interfaces;

namespace Birdhouse.Education.Patterns.Listening.Services
{
    public abstract class AsynchronousListenServiceBase : IListenService
    {
        protected abstract Task ListenBy(IListener listener, IListenSettings settings);
        
        public CancellationTokenSource BeginListen(IListener listener, IListenSettings settings)
        {
            var source = new CancellationTokenSource();
            Task.Factory.StartNew(() => ListenBy(listener, settings), source.Token);
            
            return source;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Patterns.Listening.Interfaces;
using ESparrow.Utils.Patterns.Listening.Services.Interfaces;
using ESparrow.Utils.Services.Interfaces;

namespace ESparrow.Utils.Asynchronous.Services
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
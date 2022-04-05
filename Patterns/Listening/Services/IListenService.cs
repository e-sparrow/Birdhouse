using System.Threading;
using ESparrow.Utils.Patterns.Listening.Interfaces;

namespace ESparrow.Utils.Patterns.Listening.Services.Interfaces
{
    public interface IListenService
    {
        CancellationTokenSource BeginListen(IListener listener, IListenSettings settings);
    }
}

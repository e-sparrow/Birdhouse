using System.Threading;
using Birdhouse.Education.Patterns.Listening.Interfaces;

namespace Birdhouse.Education.Patterns.Listening.Services
{
    public interface IListenService
    {
        CancellationTokenSource BeginListen(IListener listener, IListenSettings settings);
    }
}

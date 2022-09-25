using System.Threading.Tasks;
using Birdhouse.Education.Patterns.Listening.Interfaces;

namespace Birdhouse.Education.Patterns.Listening.Services
{
    public class AsynchronousListenService : AsynchronousListenServiceBase
    {
        protected override async Task ListenBy(IListener listener, IListenSettings settings)
        {
            for (int i = 0; i < settings.CallsCount; i++)
            {
                listener.Listen();
                await Task.Delay(settings.Delay);
            }
        }
    }
}

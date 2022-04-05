using System.Threading.Tasks;
using ESparrow.Utils.Patterns.Listening.Interfaces;

namespace ESparrow.Utils.Asynchronous.Services
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

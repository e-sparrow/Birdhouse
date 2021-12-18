using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums
{
    public class AsyncPendulum : PendulumBase
    {
        public AsyncPendulum() : base(TimeSpan.FromSeconds(1))
        {
            
        }
        
        public AsyncPendulum(TimeSpan period) : base(period)
        {
            
        }

        public AsyncPendulum(CancellationToken cancellationToken) : this()
        {
            _cancellationToken = cancellationToken;
        }

        public AsyncPendulum(TimeSpan period, CancellationToken cancellationToken) : base(period)
        {
            _cancellationToken = cancellationToken;
        }

        private CancellationToken _cancellationToken;

        private async Task Start()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(Period, _cancellationToken);
                Tick();
            }
        }
    }
}
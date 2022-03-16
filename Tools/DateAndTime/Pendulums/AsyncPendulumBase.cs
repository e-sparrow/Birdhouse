using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Tools.DateAndTime.Pendulums.Interfaces;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums
{
    public abstract class AsyncPendulumBase : IPendulum
    {
        protected AsyncPendulumBase(TimeSpan period)
        {
            _period = period;
        }
        
        public event Action OnTick = () => { };

        private readonly TimeSpan _period;

        private CancellationTokenSource _cancellationTokenSource;

        protected abstract Task Wait(TimeSpan period, CancellationToken token);

        public async void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await Wait(_period, _cancellationTokenSource.Token);
                OnTick.Invoke();
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
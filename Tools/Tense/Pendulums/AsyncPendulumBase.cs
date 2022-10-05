using System;
using System.Threading;
using System.Threading.Tasks;
using Birdhouse.Abstractions;
using Birdhouse.Tools.Tense.Pendulums.Interfaces;

namespace Birdhouse.Tools.Tense.Pendulums
{
    public abstract class AsyncPendulumBase : RenewableBase, IPendulum
    {
        protected AsyncPendulumBase(TimeSpan period)
        {
            _period = period;
        }
        
        public event Action OnTick = () => { };

        private readonly TimeSpan _period;

        private CancellationTokenSource _cancellationTokenSource;

        protected abstract Task Wait(TimeSpan period, CancellationToken token);

        protected override async void SetPausedInternal(bool isPaused)
        {
            if (!isPaused)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    await Wait(_period, _cancellationTokenSource.Token);
                    OnTick.Invoke();
                }
            }
            else
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
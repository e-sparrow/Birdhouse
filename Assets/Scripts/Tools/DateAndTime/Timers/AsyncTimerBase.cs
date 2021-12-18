using System;
using System.Threading;
using System.Threading.Tasks;
using ESparrow.Utils.Tools.DateAndTime.Timers.Interfaces;

namespace ESparrow.Utils.Tools.DateAndTime.Timers
{
    public abstract class AsyncTimerBase : ITimer
    {
        protected AsyncTimerBase(TimeSpan timeSpan, TimeSpan step)
        {
            TimeLeft = timeSpan;
            _step = step;
        }
        
        public event Action OnTimerStopped = () => { };
        
        public event Action<TimeSpan> OnTimerTicked = _ => { };
        public event Action<TimeSpan> OnTimerPaused = _ => { };

        private CancellationTokenSource _cancellationTokenSource;

        private readonly TimeSpan _step;

        protected abstract Task Tick(TimeSpan step, CancellationToken token);
        
        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Flow();
        }

        public void Pause()
        {
            _cancellationTokenSource.Cancel();
            OnTimerPaused.Invoke(TimeLeft);
        }

        public void Stop()
        {
            TimeLeft = TimeSpan.Zero;

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = null;
            
            OnTimerStopped.Invoke();
        }

        private async void Flow()
        {
            while (_cancellationTokenSource.Token.IsCancellationRequested)
            {
                await Tick(_step, _cancellationTokenSource.Token);
                
                TimeLeft -= _step;
                OnTimerTicked.Invoke(TimeLeft);
                
                if (TimeLeft <= TimeSpan.Zero)
                {
                    Stop();
                }
            }
        }

        public TimeSpan TimeLeft
        {
            get;
            private set;
        }
    }
}
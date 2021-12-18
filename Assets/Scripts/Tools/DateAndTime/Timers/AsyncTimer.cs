using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESparrow.Utils.Tools.DateAndTime.Timers
{
    public class AsyncTimer : AsyncTimerBase
    {
        public AsyncTimer(TimeSpan timeSpan, TimeSpan step) : base(timeSpan, step)
        {
            
        }

        protected override async Task Tick(TimeSpan step, CancellationToken token)
        {
            await Task.Delay(step, token);
        }
    }
}
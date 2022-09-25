using System;
using System.Threading.Tasks;

namespace Birdhouse.Tools.Graduating
{
    public class AsyncGradual : AsyncGradualBase
    {
        public AsyncGradual(TimeSpan step) : base(step)
        {
            
        }

        protected override async Task WaitFor(TimeSpan step)
        {
            await Task.Delay(step);
        }
    }
}

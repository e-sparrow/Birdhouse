using System;
using System.Threading.Tasks;
using Birdhouse.Tools.Graduating.Interfaces;

namespace Birdhouse.Tools.Graduating
{
    public abstract class AsyncGradualBase : IAsyncGradual
    {
        protected AsyncGradualBase(TimeSpan step)
        {
            _step = step;
        }

        private readonly TimeSpan _step;

        protected abstract Task WaitFor(TimeSpan step);
        
        public async Task Graduate(IGradualSettings settings)
        {
            for (var time = TimeSpan.Zero; time < settings.Duration; time = time.Add(_step))
            {
                var progress = settings.Ease.Evaluate((float) (time.TotalSeconds / settings.Duration.TotalSeconds));
                settings.Action.Invoke(progress);

                await WaitFor(_step);
            }
        }
    }
}

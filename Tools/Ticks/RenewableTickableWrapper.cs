using Birdhouse.Abstractions.Renewables;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks
{
    public class RenewableTickableWrapper
        : ITickable, IRenewable
    {
        public RenewableTickableWrapper(ITickable source)
        {
            _source = source;
        }

        private readonly ITickable _source;
        
        public bool IsPaused
        {
            get;
            set;
        }

        public void Tick(float deltaTime)
        {
            if (!IsPaused)
            {
                _source.Tick(deltaTime);
            }
        }
    }
}
using System.Collections.Generic;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks
{
    public sealed class CompositeTickable
        : ICompositeTickable
    {
        private readonly ICollection<ITickable> _tickables 
            = new List<ITickable>();

        public void Tick(float deltaTime)
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(deltaTime);
            }
        }

        public ICompositeTickable Append(ITickable other)
        {
            _tickables.Add(other);
            return this;
        }

        public void Dispose()
        {
            _tickables.Clear();
        }
    }
}
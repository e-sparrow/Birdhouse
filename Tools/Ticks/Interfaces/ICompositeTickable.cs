using System;

namespace Birdhouse.Tools.Ticks.Interfaces
{
    public interface ICompositeTickable
        : ITickable, IDisposable
    {
        ICompositeTickable Append(ITickable other);
    }
}
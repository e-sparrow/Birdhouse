using System;

namespace Birdhouse.Tools.Ticks.Interfaces
{
    public interface ITickProvider
    {
        IDisposable RegisterTick(Action<float> tick);
    }
}
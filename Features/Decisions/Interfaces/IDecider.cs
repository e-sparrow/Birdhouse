using System;

namespace Birdhouse.Features.Decisions.Interfaces
{
    public interface IDecider<out TOut>
        : IDisposable
    {
        event Action<TOut> OnDecide;
    }
}
using System;

namespace Birdhouse.Features.Decisions.Interfaces
{
    public interface ICompositeDecider<TOut>
        : IDecider<TOut>, IDisposable
    {
        ICompositeDecider<TOut> Append(IDecider<TOut> decider);
    }
}
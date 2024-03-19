using System;

namespace Birdhouse.Features.Decisions.Interfaces
{
    public interface IDecision<out TOut>
        : IDisposable
    {
        event Action OnDecide;
        
        TOut Value
        {
            get;
        }
    }
}
using System;

namespace Birdhouse.Features.Registries.Interfaces
{
    public interface IBlockerRegistry
    {
        IDisposable RegisterBlocker();
        
        bool IsBlocked();
    }
}
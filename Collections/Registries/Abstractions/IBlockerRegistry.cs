using System;

namespace Birdhouse.Collections.Registries.Abstractions
{
    public interface IBlockerRegistry
    {
        IDisposable RegisterBlocker();
        
        bool IsBlocked();
    }
}
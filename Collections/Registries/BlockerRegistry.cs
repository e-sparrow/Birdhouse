using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Collections.Registries
{
    public sealed class BlockerRegistry
        : IBlockerRegistry
    {
        private int _blockersCount = 0;
        
        public IDisposable RegisterBlocker()
        {
            _blockersCount++;
            return new CallbackDisposable(() => _blockersCount--);
        }

        public bool IsBlocked() => _blockersCount > 0;
    }
}
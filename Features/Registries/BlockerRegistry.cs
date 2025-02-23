using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public sealed class BlockerRegistry
        : IBlockerRegistry
    {
        private int _blockersCount = 0;
        
        public IDisposable RegisterBlocker()
        {
            _blockersCount++;
            
            var result = new CallbackDisposable(() => _blockersCount--);
            return result;
        }

        public bool IsBlocked()
        {
            var result = _blockersCount > 0;
            return result;
        }
    }
}
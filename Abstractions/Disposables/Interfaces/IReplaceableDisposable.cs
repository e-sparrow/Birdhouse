using System;

namespace Birdhouse.Abstractions.Disposables.Interfaces
{
    public interface IReplaceableDisposable 
        : IDisposable
    {
        void Replace(IDisposable other);
    }
}
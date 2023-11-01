using System;

namespace Birdhouse.Abstractions.Disposables.Interfaces
{
    public interface ICompositeDisposable
        : IDisposable
    {
        ICompositeDisposable Append(IDisposable other);
    }
}
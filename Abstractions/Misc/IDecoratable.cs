using System;

namespace Birdhouse.Abstractions.Misc
{
    public interface IDecoratable<T>
    {
        IDisposable Decorate(T other);
    }
}
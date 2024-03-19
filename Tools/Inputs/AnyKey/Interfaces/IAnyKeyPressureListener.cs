using System;

namespace Birdhouse.Tools.Inputs.AnyKey.Interfaces
{
    public interface IAnyKeyPressureListener<out TKey>
        : IDisposable
    {
        event Action<TKey> OnPressurePerformed;
    }
}
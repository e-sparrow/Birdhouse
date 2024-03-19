using System;
using Birdhouse.Tools.Inputs.Pressures.Enums;

namespace Birdhouse.Tools.Inputs.AnyKey.Interfaces
{
    public interface IAnyKeyListener<out TKey>
        : IDisposable
    {
        IAnyKeyPressureListener<TKey> RegisterListener(EPressureState state);
    }
}
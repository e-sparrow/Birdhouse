 using System;
using Birdhouse.Abstractions.Initializables.Interfaces;

namespace Birdhouse.Abstractions.Configurables.Interfaces
{
    public interface IRemoteConfigInitializer
        : IAsyncInitializable
    {
        event Action OnSetDefaults;
        event Action OnFetch;
    }

    public interface IRemoteConfigInitializer<out TUpdate>
        : IRemoteConfigInitializer
    {
        event Action<TUpdate> OnConfigUpdate;
    }
}
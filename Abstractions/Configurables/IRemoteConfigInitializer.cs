using System;
using Birdhouse.Abstractions.Initializables;

namespace Birdhouse.Abstractions.Configurables
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
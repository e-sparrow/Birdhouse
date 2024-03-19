using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Configurables.Interfaces;
using Birdhouse.Abstractions.Initializables;
using Firebase.RemoteConfig;

namespace Birdhouse.Abstractions.Configurables.Firebase
{
    public sealed class FirebaseRemoteConfigInitializer
        : IRemoteConfigInitializer<ConfigUpdateEventArgs>, IDisposable
    {
        public FirebaseRemoteConfigInitializer(Dictionary<string, object> defaults = null)
        {
            defaults ??= new Dictionary<string, object>();
            
            _defaults = defaults;
        }

        public event Action OnSetDefaults = () => { };
        public event Action OnFetch = () => { };
        
        public event Action<ConfigUpdateEventArgs> OnConfigUpdate = _ => { };

        private readonly Dictionary<string, object> _defaults;

        private bool _isInitialized = false;

        public async Task Initialize()
        {
            if (_isInitialized)
            {
                throw new AlreadyInitializedException($"{typeof(FirebaseRemoteConfigInitializer)} is already initialized!");
            }
            
            _isInitialized = true;
            
            await FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(_defaults);
            OnSetDefaults.Invoke();
            
            await FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            OnFetch.Invoke();
            
            FirebaseRemoteConfig.DefaultInstance.OnConfigUpdateListener += UpdateConfig;
        }

        public void Dispose()
        {
            FirebaseRemoteConfig.DefaultInstance.OnConfigUpdateListener -= UpdateConfig;
        }

        private void UpdateConfig(object sender, ConfigUpdateEventArgs args)
        {
            OnConfigUpdate.Invoke(args);
        }
    }
}
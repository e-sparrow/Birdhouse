using System;
using System.Threading.Tasks;
using Birdhouse.Abstractions.Configurables.Interfaces;
using Birdhouse.Abstractions.Initializables;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace Birdhouse.Abstractions.Configurables.Unity
{
    public class UnityRemoteConfigInitializer
        : IRemoteConfigInitializer
    {
        public UnityRemoteConfigInitializer(bool isLogging = true, object userAttributes = null, object appAttributes = null)
        {
            _isLogging = isLogging;
            
            _userAttributes = userAttributes;
            _appAttributes = appAttributes;
        }
        
        public event Action OnSetDefaults = () => { };
        public event Action OnFetch = () => { };

        private readonly bool _isLogging;
        
        private readonly object _userAttributes;
        private readonly object _appAttributes;
        
        private bool _isInitialized;
        
        public async Task Initialize()
        {
            if (_isInitialized)
            {
                throw new AlreadyInitializedException($"{typeof(UnityRemoteConfigInitializer)} is already initialized!");
            }
            
            _isInitialized = true;
            
            if (Utilities.CheckForInternetConnection())
            {
                RemoteConfigService.Instance.FetchCompleted += Apply;
                await RemoteConfigService.Instance.FetchConfigsAsync(_userAttributes, _appAttributes);
            }
        }

        private void Apply(ConfigResponse response)
        {
            RemoteConfigService.Instance.FetchCompleted -= Apply;
            
            if (response.requestOrigin == ConfigOrigin.Default)
            {
                OnSetDefaults.Invoke();
            }
            
            if (_isLogging)
            {
                const string DefaultConfig =
                    "No settings loaded this session and no local cache file exists; using default values.";
                const string CachedConfig =
                    "No settings loaded this session; using cached values from a previous session.";

                var remoteConfig = $"New settings loaded this session; update values accordingly. \n" +
                                   $"RemoteConfigService.Instance.appConfig fetched: {RemoteConfigService.Instance.appConfig.config}";

                switch (response.requestOrigin)
                {
                    case ConfigOrigin.Default:
                        Debug.Log(DefaultConfig);
                        break;

                    case ConfigOrigin.Cached:
                        Debug.Log(CachedConfig);
                        break;

                    case ConfigOrigin.Remote:
                        Debug.Log(remoteConfig);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            OnFetch.Invoke();
        }
    }
}
using System;
using Birdhouse.Abstractions.Configurables.Interfaces;
using Unity.Services.RemoteConfig;

namespace Birdhouse.Abstractions.Configurables.Unity
{
    public class UnityRemoteConfigValue<T>
        : IConfigurableValue<T> where T : class
    {
        public UnityRemoteConfigValue(string key, T defaultValue = null)
        {
            _key = key;
            _defaultValue = defaultValue;
        }

        private readonly string _key;
        private readonly T _defaultValue;
        
        public bool TryGetValue(out T value)
        {
            value = default;

            var isValid = RemoteConfigService.Instance.appConfig.HasKey(_key);
            if (!isValid)
            {
                throw new ArgumentException($"Unity remote config can't find value with key {_key}!");
            }
            
            if (value is bool && _defaultValue is bool defaultBool)
            {
                RemoteConfigService.Instance.appConfig.GetBool(_key, defaultBool);
                return true;
            }
            
            if (value is float && _defaultValue is float defaultFloat)
            {
                RemoteConfigService.Instance.appConfig.GetFloat(_key, defaultFloat);
                return true;
            }
            if (value is int && _defaultValue is int defaultInt)
            {
                RemoteConfigService.Instance.appConfig.GetInt(_key, defaultInt);
                return true;
            }
            
            if (value is string && _defaultValue is string defaultString)
            {
                RemoteConfigService.Instance.appConfig.GetString(_key, defaultString);
                return true;
            }
            
            if (value is string && _defaultValue is long defaultLong)
            {
                RemoteConfigService.Instance.appConfig.GetLong(_key, defaultLong);
                return true;
            }

            var message = $"Firebase Remote Config doesn't contain value with key \"{_key}\" of type {typeof(T)}";
            throw new ArgumentException(message);
        }
    }
}
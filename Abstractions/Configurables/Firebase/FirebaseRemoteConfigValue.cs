using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Configurables.Interfaces;
using Firebase.RemoteConfig;

namespace Birdhouse.Abstractions.Configurables.Firebase
{
    public class FirebaseRemoteConfigValue<T>
        : IConfigurableValue<T> where T : class
    {
        public FirebaseRemoteConfigValue(string key)
        {
            _key = key;
        }
        
        private readonly string _key;
        
        public bool TryGetValue(out T value)
        {
            value = default;
            
            var configValue = FirebaseRemoteConfig
                .DefaultInstance
                .GetValue(_key);

            if (value is IEnumerable<byte>)
            {
                value = configValue.ByteArrayValue as T;
                return true;
            }

            if (value is bool)
            {
                value = configValue.BooleanValue as T;
                return true;
            }

            if (value is double)
            {
                value = configValue.DoubleValue as T;
                return true;
            }

            if (value is long)
            {
                value = configValue.LongValue as T;
                return true;
            }

            if (value is string)
            {
                value = configValue.StringValue as T;
                return true;
            }

            var message = $"Firebase Remote Config doesn't contain value with key \"{_key}\" of type {typeof(T)}";
            throw new ArgumentException(message);
        }
    }
}
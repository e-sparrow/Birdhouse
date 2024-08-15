using System;
using Birdhouse.Features.Registries;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public static class RegisterWithIdExtensions
    {
        public static IDisposable RegisterWithId<TId>(this IFeatureFactory self, object value, TId id)
        {
            var hasFeature = self.TryGetFeature<IdDictionary<TId, object>>(out var feature);
            if (hasFeature)
            {
                var result = feature.Register(id, value);
                return result;
            }
            else
            {
                var dictionary = new IdDictionary<TId, object>();
                self.RegisterValue(dictionary);
                
                var result = dictionary.Register(id, value);
                return result;
            }
        }
        
        public static IDisposable RegisterWithId<TId, TValue>(this IFeatureFactory self, TValue value, TId id)
        {
            var hasFeature = self.TryGetFeature<IdDictionary<TId, TValue>>(out var feature);
            if (hasFeature)
            {
                var result = feature.Register(id, value);
                return result;
            }
            else
            {
                var dictionary = new IdDictionary<TId, TValue>();
                self.RegisterValue(dictionary);
                
                var result = dictionary.Register(id, value);
                return result;
            }
        }

        public static bool TryGetFeatureWithId<TId>(this IFeatureContainer self, TId id, out object value)
        {
            value = default;
            
            var hasFeature = self.TryGetFeature<IdDictionary<TId, object>>(out var feature);
            if (hasFeature)
            {
                var result = feature.TryGetValue(id, out value);
                return result;
            }

            return false;
        }

        public static bool TryGetFeatureWithId<TId, TValue>(this IFeatureContainer self, TId id, out TValue value)
        {
            value = default;
            
            var hasFeature = self.TryGetFeature<IdDictionary<TId, TValue>>(out var feature);
            if (hasFeature)
            {
                var result = feature.TryGetValue(id, out value);
                return result;
            }

            return false;
        }

        private sealed class IdDictionary<TId, TValue>
            : RegistryDictionary<TId, TValue>
        {
            
        }
    }
}
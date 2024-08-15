using System;
using System.Collections.Generic;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public static class RegisterInHeapExtensions
    {
        public static IDisposable RegisterInHeap<T>(this IFeatureFactory self, T value)
        {
            var hasFeature = self.TryGetFeature<IRegistryEnumerable<T>>(out var feature);
            if (hasFeature)
            {
                var result = feature.Register(value);
                return result;
            }
            else
            {
                var enumerable = new RegistryEnumerable<T>();
                self.RegisterValue<IRegistryEnumerable<T>>(enumerable);
                
                var result = enumerable.Register(value);
                return result;
            }
        }

        public static bool TryGetFeaturesHeap<T>(this IFeatureContainer self, out IEnumerable<T> result)
        {
            var hasFeature = self.TryGetFeature<IRegistryEnumerable<T>>(out var registry);
            result = registry;
            
            return hasFeature;
        }
    }
}
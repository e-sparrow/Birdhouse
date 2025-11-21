using System;
using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Collections.Registries
{
    public static class RegistryExtensions
    {
        public static IFluentRegistrationBuilder<TIn> RegisterAndAppend<TIn>
            (this IRegistry<TIn> self, TIn value) => new FluentRegistrationBuilder<TIn>(self).RegisterAndAppend(value);
        
        public static bool TryGetValue<TKey, TValue>
            (this IRegistryDictionary<TKey, TValue> self, TKey key, out TValue value)
        {
            value = default;
            
            var result = self.ContainsKey(key);
            if (result) value = self[key];
            return result;
        }
    }
}
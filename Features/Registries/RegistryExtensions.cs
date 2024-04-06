using System;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public static class RegistryExtensions
    {
        public static IFluentRegistrationBuilder<TIn> RegisterAndAppend<TIn>
            (this IRegistry<TIn> self, TIn value)
        {
            var result = new FluentRegistrationBuilder<TIn>(self)
                .RegisterAndAppend(value);
            
            return result;
        }
        
        public static bool TryGetValue<TKey, TValue>
            (this IRegistryDictionary<TKey, TValue> self, TKey key, out TValue value)
        {
            value = default;
            
            var result = self.ContainsKey(key);
            if (result)
            {
                value = self[key];
                return true;
            }

            return false;
        }
    }
}
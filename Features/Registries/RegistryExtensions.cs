using System;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public static class RegistryExtensions
    {
        // Fluent variant of "Register" method for registries
        public static TRegistry Register<TRegistry, TElement, TToken>
            (this TRegistry self, TElement element, out TToken token)
            where TRegistry : IRegistry<TElement, TToken>
            where TToken : IDisposable
        {
            token = self.Register(element);
            return self;
        }
    }
}
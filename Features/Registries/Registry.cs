using System;
using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Features.Registries
{
    public class Registry<TElement> : RegistryBase<TElement, IDisposable>
    {
        private readonly IRegistryEnumerable<TElement> _registry = new RegistryEnumerable<TElement>();

        protected override IDisposable CreateToken(TElement element)
        {
            var result = _registry.Register(element);
            return result;
        }
    }

    public class Registry : Registry<object>, IRegistry
    {
        
    }
}
using System;
using Birdhouse.Abstractions.Disposables;
using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Collections.Registries
{
    public sealed class FluentRegistrationBuilder<TIn>
        : IFluentRegistrationBuilder<TIn>
    {
        public FluentRegistrationBuilder(IRegistry<TIn> registry)
        {
            _registry = registry;
        }

        private readonly IRegistry<TIn> _registry;
        private readonly CompositeDisposable _composite;
        
        public IDisposable Build()
        {
            return _composite;
        }
        
        public IFluentRegistrationBuilder<TIn> RegisterAndAppend(TIn input)
        {
            var token = _registry.Register(input);
            
            _composite.Append(token);
            return this;
        }
    }
}
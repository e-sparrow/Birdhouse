using System;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public sealed class FeatureFactoryToContainerAdapter
        : IFeatureContainer
    {
        public FeatureFactoryToContainerAdapter(IFeatureFactory factory)
        {
            _factory = factory;
        }

        private readonly IFeatureFactory _factory;
        
        public bool TryGetFeature(Type type, out object feature)
        {
            var result = _factory.TryGetOrCreateFeature(type, out feature);
            return result;
        }
    }
}
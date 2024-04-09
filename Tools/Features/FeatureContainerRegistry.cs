using System;
using Birdhouse.Features.Registries;
using Birdhouse.Features.Registries.Interfaces;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public sealed class FeatureContainerRegistry
        : IFeatureContainerRegistry
    {
        private readonly IRegistryEnumerable<IFeatureContainer> _containers
            = new RegistryEnumerable<IFeatureContainer>();
        
        public IDisposable Register(IFeatureContainer element)
        {
            var result = _containers.Register(element);
            return result;
        }

        public bool TryGetFeature(Type type, out object feature)
        {
            feature = null;
            
            foreach (var container in _containers)
            {
                var hasFeature = container.TryGetFeature(type, out feature);
                if (hasFeature)
                {
                    return true;
                }
            }

            return false;
        }

        public void Dispose()
        {
            _containers.Dispose();
        }
    }
}
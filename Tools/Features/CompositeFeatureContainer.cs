using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Misc.Interfaces;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public sealed class CompositeFeatureContainer
        : IFeatureContainer, IComposite<CompositeFeatureContainer, IFeatureContainer>
    {
        private readonly ICollection<IFeatureContainer> _containers
            = new List<IFeatureContainer>();
        
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

        public CompositeFeatureContainer Append(IFeatureContainer other)
        {
            _containers.Add(other);
            return this;
        }
    }
}
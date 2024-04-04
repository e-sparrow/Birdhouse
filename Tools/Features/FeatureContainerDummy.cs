using System;
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public sealed class FeatureContainerDummy
        : IFeatureContainer
    {
        public bool TryGetFeature(Type type, out object feature)
        {
            feature = null;
            return false;
        }
    }
}
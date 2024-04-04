using System;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureContainer
    {
        bool TryGetFeature(Type type, out object feature);
    }
}
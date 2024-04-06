using System;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureContainer<in TIn>
    {
        bool TryGetFeature(Type type, TIn input, out object feature);
    }
    
    public interface IFeatureContainer
    {
        bool TryGetFeature(Type type, out object feature);
    }
}
using System;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureContainer
    {
        bool TryGetFeature(Type type, out object feature);
    }
    
    public interface IFeatureContainer<in TBase>
    {
        bool TryGetFeature<T>(out T feature)
            where T : TBase;
    }
}
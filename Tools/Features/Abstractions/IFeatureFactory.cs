using System;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureFactory
        : IDisposable
    {
        IDisposable RegisterParameter(object parameter);
        IDisposable RegisterFeature(Type type, Func<object[], object> creator);
        
        public bool TryGetOrCreateFeature(Type featureType, out object result);
    }
}
using Birdhouse.Tools.Features.Abstractions;

namespace Birdhouse.Tools.Features
{
    public static class FeatureExtensions
    {
        public static bool TryGetFeature<T>(this IFeatureContainer self, out T result)
        {
            result = default;
            
            var hasFeature = self.TryGetFeature(typeof(T), out var feature);
            if (hasFeature)
            {
                result = (T) feature;
            }

            return hasFeature;
        }
    }
}
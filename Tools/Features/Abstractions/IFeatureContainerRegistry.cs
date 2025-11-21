using Birdhouse.Collections.Registries.Abstractions;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureContainerRegistry
        : IFeatureContainer, IRegistry<IFeatureContainer>
    {
        
    }
}
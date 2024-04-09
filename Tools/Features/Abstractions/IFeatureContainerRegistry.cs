using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureContainerRegistry
        : IFeatureContainer, IRegistry<IFeatureContainer>
    {
        
    }
}
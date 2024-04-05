using Birdhouse.Features.Registries.Interfaces;

namespace Birdhouse.Tools.Features.Abstractions
{
    public interface IFeatureRegistry
        : IFeatureContainer, IRegistry<IFeatureContainer>
    {
        
    }
}
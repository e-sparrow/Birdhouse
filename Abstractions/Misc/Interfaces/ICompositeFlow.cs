using Birdhouse.Abstractions.Composites.Abstractions;

namespace Birdhouse.Abstractions.Misc.Interfaces
{
    public interface ICompositeFlow
        : IFlow, IComposite<ICompositeFlow, IFlow>
    {
        
    }
}
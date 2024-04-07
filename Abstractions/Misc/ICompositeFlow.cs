using Birdhouse.Abstractions.Composites;

namespace Birdhouse.Abstractions.Misc
{
    public interface ICompositeFlow
        : IFlow, IComposite<ICompositeFlow, IFlow>
    {
        
    }
}
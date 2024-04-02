namespace Birdhouse.Abstractions.Misc.Interfaces
{
    public interface ICompositeFlow
        : IFlow, IComposite<ICompositeFlow, IFlow>
    {
        
    }
}
namespace Birdhouse.Abstractions.Composites
{
    public interface IComposite<out TSelf, in TElement>
        where TSelf : IComposite<TSelf, TElement>, TElement
    {
        TSelf Append(TElement other);
    }
    
    public interface ICreatableComposite<out TSelf, in TElement>
        : IComposite<TSelf, TElement>
        where TSelf : ICreatableComposite<TSelf, TElement>, TElement, new()
    {
        
    }
}
namespace Birdhouse.Abstractions.Composites.Abstractions
{
    public interface IComposite<out TSelf, in TElement>
        where TSelf : IComposite<TSelf, TElement>
    {
        TSelf Append(TElement other);
    }
}
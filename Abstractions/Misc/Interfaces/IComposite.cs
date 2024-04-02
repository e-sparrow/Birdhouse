namespace Birdhouse.Abstractions.Misc.Interfaces
{
    public interface IComposite<T, in TElement>
        where T : IComposite<T, TElement>
    {
        T Append(TElement other);
    }
}
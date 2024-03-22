namespace Birdhouse.Abstractions.Misc.Interfaces
{
    public interface ICompositeFlow
        : IFlow
    {
        ICompositeFlow Append(IFlow other);
    }
}
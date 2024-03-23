namespace Birdhouse.Abstractions.Builders.Abstractions
{
    public interface IBuilder<out TSelf, out T>
        where TSelf : IBuilder<TSelf, T>
    {
        T Build();
    }
}
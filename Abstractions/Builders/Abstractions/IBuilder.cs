namespace Birdhouse.Abstractions.Builders.Abstractions
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
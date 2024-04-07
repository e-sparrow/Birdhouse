namespace Birdhouse.Abstractions.Configurables
{
    public interface IConfigurableValue<T>
    {
        bool TryGetValue(out T value);
    }
}
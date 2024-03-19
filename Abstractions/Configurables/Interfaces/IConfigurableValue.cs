namespace Birdhouse.Abstractions.Configurables.Interfaces
{
    public interface IConfigurableValue<T>
    {
        bool TryGetValue(out T value);
    }
}
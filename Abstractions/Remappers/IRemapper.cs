namespace Birdhouse.Abstractions.Remappers
{
    public interface IRemapper<in TFrom, out TTo>
    {
        TTo Remap(TFrom input);
    }
}
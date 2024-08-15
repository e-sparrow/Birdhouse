namespace Birdhouse.Abstractions.Remappers
{
    public interface IConditionalRemapper<in TFrom, TTo>
    {
        bool TryRemap(TFrom input, out TTo result);
    }
}
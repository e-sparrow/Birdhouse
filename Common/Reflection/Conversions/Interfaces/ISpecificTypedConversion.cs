namespace Birdhouse.Common.Reflection.Conversions.Interfaces
{
    public interface ISpecificTypedConversion<in TFrom, out TTo>
    {
        TTo Convert(TFrom value);
    }
}

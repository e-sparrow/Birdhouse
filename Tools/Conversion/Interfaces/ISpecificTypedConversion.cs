namespace Birdhouse.Tools.Conversion.Interfaces
{
    public interface ISpecificTypedConversion<in TFrom, out TTo>
    {
        TTo Convert(TFrom value);
    }
}

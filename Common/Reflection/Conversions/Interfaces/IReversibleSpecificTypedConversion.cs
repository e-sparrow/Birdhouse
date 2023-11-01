namespace Birdhouse.Common.Reflection.Conversions.Interfaces
{
    public interface IReversibleSpecificTypedConversion<TFrom, TTo>
    {
        TTo Convert(TFrom value);
        TFrom Convert(TTo value);
    }
}

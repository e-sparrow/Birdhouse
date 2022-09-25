namespace Birdhouse.Tools.Conversion.Interfaces
{
    public interface IReversibleSpecificTypedConversion<TFrom, TTo>
    {
        TTo Convert(TFrom value);
        TFrom Convert(TTo value);
    }
}

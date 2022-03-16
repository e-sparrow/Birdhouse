using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public abstract class ReversibleSpecificTypedConversionBase<TFrom, TTo> : IReversibleSpecificTypedConversion<TFrom, TTo>
    {
        public abstract TTo Convert(TFrom value);
        public abstract TFrom Convert(TTo value);
    }
}

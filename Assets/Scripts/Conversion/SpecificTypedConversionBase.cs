using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public abstract class SpecificTypedConversionBase<TFrom, TTo> : ISpecificTypedConversion<TFrom, TTo>
    {
        public abstract TTo Convert(TFrom value);
    }
}

using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion
{
    public abstract class SpecificTypedConversionBase<TFrom, TTo> : ISpecificTypedConversion<TFrom, TTo>
    {
        public abstract TTo Convert(TFrom value);
    }
}

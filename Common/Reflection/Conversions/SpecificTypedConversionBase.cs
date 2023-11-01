using Birdhouse.Common.Reflection.Conversions.Interfaces;

namespace Birdhouse.Common.Reflection.Conversions
{
    public abstract class SpecificTypedConversionBase<TFrom, TTo> : ISpecificTypedConversion<TFrom, TTo>
    {
        public abstract TTo Convert(TFrom value);
    }
}

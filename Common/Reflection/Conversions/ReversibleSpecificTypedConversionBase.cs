using Birdhouse.Common.Reflection.Conversions.Interfaces;

namespace Birdhouse.Common.Reflection.Conversions
{
    public abstract class ReversibleSpecificTypedConversionBase<TFrom, TTo> : IReversibleSpecificTypedConversion<TFrom, TTo>
    {
        public abstract TTo Convert(TFrom value);
        public abstract TFrom Convert(TTo value);
    }
}

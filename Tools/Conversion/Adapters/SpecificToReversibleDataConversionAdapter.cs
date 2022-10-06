using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion.Adapters
{
    public class SpecificToReversibleDataConversionAdapter<TFrom, TTo> : IReversibleSpecificTypedConversion<TFrom, TTo>
    {
        public SpecificToReversibleDataConversionAdapter
        (
            ISpecificTypedConversion<TFrom, TTo> forward,
            ISpecificTypedConversion<TTo, TFrom> back
        )
        {
            _forward = forward;
            _back = back;
        }

        private readonly ISpecificTypedConversion<TFrom, TTo> _forward;
        private readonly ISpecificTypedConversion<TTo, TFrom> _back;

        public TTo Convert(TFrom value)
        {
            var result = _forward.Convert(value);
            return result;
        }

        public TFrom Convert(TTo value)
        {
            var result = _back.Convert(value);
            return result;
        }
    }
}
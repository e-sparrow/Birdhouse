using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion.Adapters
{
    public class ReversibleDataConversionSwapper<TFrom, TTo> : IReversibleSpecificTypedConversion<TTo, TFrom>
    {
        public ReversibleDataConversionSwapper(IReversibleSpecificTypedConversion<TFrom, TTo> conversion)
        {
            _conversion = conversion;
        }

        private readonly IReversibleSpecificTypedConversion<TFrom, TTo> _conversion;

        public TFrom Convert(TTo value)
        {
            var result = _conversion.Convert(value);
            return result;
        }

        public TTo Convert(TFrom value)
        {
            var result = _conversion.Convert(value);
            return result;
        }
    }
}
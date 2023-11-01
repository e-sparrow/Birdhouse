namespace Birdhouse.Common.Reflection.Conversions
{
    public class SpecificTypedConversion<TFrom, TTo> : SpecificTypedConversionBase<TFrom, TTo>
    {
        public SpecificTypedConversion(SpecificConversion<TFrom, TTo> conversion)
        {
            _conversion = conversion;
        }

        private readonly SpecificConversion<TFrom, TTo> _conversion;

        public override TTo Convert(TFrom value)
        {
            var result = _conversion.Invoke(value);
            return result;
        }
    }
}
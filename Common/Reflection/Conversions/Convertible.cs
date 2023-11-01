namespace Birdhouse.Common.Reflection.Conversions
{
    public class Convertible<TFrom, TTo> : ConvertibleBase<TFrom, TTo>
    {
        public Convertible(TFrom value, SpecificConversion<TFrom, TTo> conversion) : base(value)
        {
            _conversion = conversion;
        }

        private readonly SpecificConversion<TFrom, TTo> _conversion;

        protected override TTo ConvertFrom(TFrom value)
        {
            var result = _conversion.Invoke(value);
            return result;
        }
    }
}

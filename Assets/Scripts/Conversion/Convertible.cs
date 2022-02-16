namespace ESparrow.Utils.Conversion
{
    public class Convertible<TFrom, TTo> : ConvertibleBase<TFrom, TTo>
    {
        public Convertible(TFrom value, Conversion<TFrom, TTo> conversion) : base(value)
        {
            _conversion = conversion;
        }

        private readonly Conversion<TFrom, TTo> _conversion;

        protected override TTo ConvertFrom(TFrom value)
        {
            return _conversion.Invoke(value);
        }
    }
}

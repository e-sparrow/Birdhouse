using Birdhouse.Common.Reflection.Conversions.Interfaces;

namespace Birdhouse.Common.Reflection.Conversions
{
    public abstract class ConvertibleBase<TFrom, TTo> : IConvertible<TTo>
    {
        protected ConvertibleBase(TFrom value)
        {
            _value = value;
        }

        private readonly TFrom _value;

        protected abstract TTo ConvertFrom(TFrom value);

        public TTo Convert()
        {
            var result = ConvertFrom(_value);
            return result;
        }
    }
}

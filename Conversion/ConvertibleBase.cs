using System;
using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
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
            return ConvertFrom(_value);
        }
    }
}

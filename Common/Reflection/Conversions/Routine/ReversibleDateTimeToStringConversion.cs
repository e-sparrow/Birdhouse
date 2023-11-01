using System;
using System.Globalization;

namespace Birdhouse.Common.Reflection.Conversions.Routine
{
    public class ReversibleDateTimeToStringConversion : ReversibleSpecificTypedConversionBase<DateTime, string>
    {
        public ReversibleDateTimeToStringConversion(IFormatProvider formatProvider = null)
        {
            formatProvider ??= CultureInfo.InvariantCulture;
            _formatProvider = formatProvider;
        }

        private readonly IFormatProvider _formatProvider;
        
        public override string Convert(DateTime value)
        {
            var result = value.ToString(_formatProvider);
            return result;
        }

        public override DateTime Convert(string value)
        {
            var result = DateTime.Parse(value, _formatProvider);
            return result;
        }
    }
}
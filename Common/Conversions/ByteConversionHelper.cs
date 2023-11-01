using System;
using Birdhouse.Common.Conversions.Interfaces;

namespace Birdhouse.Common.Conversions
{
    public static class ByteConversionHelper
    {
        public static readonly Lazy<IBytesConverter<string>> DefaultBytesToStringConverter
            = new Lazy<IBytesConverter<string>>(GetDefaultBytesToStringConverter);

        private static IBytesConverter<string> GetDefaultBytesToStringConverter()
        {
            var result = new BytesToStringConverter();
            return result;
        }
    }
}
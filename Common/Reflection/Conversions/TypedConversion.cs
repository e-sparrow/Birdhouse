using Birdhouse.Common.Reflection.Conversions.Interfaces;

namespace Birdhouse.Common.Reflection.Conversions
{
    public class TypedConversion : TypedConversionBase
    {
        public TypedConversion(ITypedConversionInfo info)
        {
            Info = info;
            
            _conversion = Info.Conversion;
        }

        private readonly Conversion _conversion;

        public override object Convert(object value)
        {
            var result = _conversion.Invoke(value);
            return result;
        }

        public sealed override ITypedConversionInfo Info
        {
            get;
        }
    }
}

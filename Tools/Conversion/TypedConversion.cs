using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion
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

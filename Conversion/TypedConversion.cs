using System;
using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public class TypedConversion : TypedConversionBase
    {
        public TypedConversion(ITypedConversionInfo info)
        {
            Info = info;
            
            _conversion = Info.Conversion;
        }

        private readonly Conversion<object, object> _conversion;

        public override object Convert(object value)
        {
            return _conversion.Invoke(value);
        }

        public sealed override ITypedConversionInfo Info
        {
            get;
        }
    }
}

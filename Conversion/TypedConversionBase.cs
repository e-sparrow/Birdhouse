using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public abstract class TypedConversionBase : ITypedConversion
    {
        public abstract object Convert(object value);

        public abstract ITypedConversionInfo Info
        {
            get;
        }
    }
}

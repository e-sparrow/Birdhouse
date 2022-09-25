using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion
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

using Birdhouse.Common.Reflection.Conversions.Interfaces;

namespace Birdhouse.Common.Reflection.Conversions
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

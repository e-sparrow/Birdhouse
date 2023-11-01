namespace Birdhouse.Common.Reflection.Conversions.Interfaces
{
    public interface ITypedConversionInfo : IConversionInfo
    {
        Conversion Conversion
        {
            get;
        }
    }
}

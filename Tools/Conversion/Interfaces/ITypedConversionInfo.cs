namespace Birdhouse.Tools.Conversion.Interfaces
{
    public interface ITypedConversionInfo : IConversionInfo
    {
        Conversion Conversion
        {
            get;
        }
    }
}

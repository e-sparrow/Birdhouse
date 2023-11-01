namespace Birdhouse.Common.Reflection.Conversions.Interfaces
{
    public interface ITypedConversion
    {
        object Convert(object value);

        ITypedConversionInfo Info
        {
            get;
        }
    }
}

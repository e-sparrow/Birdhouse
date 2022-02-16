namespace ESparrow.Utils.Conversion.Interfaces
{
    public interface ITypedConversionInfo : IConversionInfo
    {
        Conversion<object, object> Conversion
        {
            get;
        }
    }
}

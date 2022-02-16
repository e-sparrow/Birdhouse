namespace ESparrow.Utils.Conversion.Interfaces
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

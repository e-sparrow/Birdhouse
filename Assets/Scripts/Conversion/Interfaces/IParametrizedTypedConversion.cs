namespace ESparrow.Utils.Conversion.Interfaces
{
    public interface IParametrizedTypedConversion<in TParameter>
    {
        object Convert(object value, TParameter parameter);

        IParametrizedTypedConversionInfo Info
        {
            get;
        }
    }
}

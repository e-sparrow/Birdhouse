using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public abstract class ParametrizedTypedConversionBase<TParameter> : IParametrizedTypedConversion<TParameter>
    {
        public abstract object Convert(object value, TParameter parameter);

        public abstract IParametrizedTypedConversionInfo Info
        {
            get;
        }
    }
}
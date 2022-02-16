using System;
using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public class ParametrizedTypedConversion<TParameter> : ParametrizedTypedConversionBase<TParameter>
    {
        public ParametrizedTypedConversion(IParametrizedTypedConversionInfo info)
        {
            Info = info;
            
            _conversion = CreateCorrectConversion(Info.ParameterType, Info.Conversion);
        }

        private static ParametrizedConversion<object, object, TParameter> CreateCorrectConversion(Type parameterType, ParametrizedConversion<object, object, object> oldConversion)
        {
            if (parameterType != typeof(TParameter))
            {
                throw new ArgumentException($"Parameter with name {parameterType.Name} doesn't fit corresponding conversion!");
            }
            
            return (value, parameter) => oldConversion.Invoke(value, parameter);
        }

        private readonly ParametrizedConversion<object, object, TParameter> _conversion;
        
        public override object Convert(object value, TParameter parameter)
        {
            return _conversion.Invoke(value, parameter);
        }

        public sealed override IParametrizedTypedConversionInfo Info
        {
            get;
        }
    }
}

using System;
using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion
{
    public readonly struct ParametrizedTypedConversionInfo : IParametrizedTypedConversionInfo
    {
        public ParametrizedTypedConversionInfo(Type originalType, Type finalType, Type parameterType, ParametrizedConversion<object, object, object> conversion)
        {
            OriginalType = originalType;
            FinalType = finalType;
            ParameterType = parameterType;
            Conversion = conversion;
        }

        public Type OriginalType
        {
            get;
        }

        public Type FinalType
        {
            get;
        }

        public Type ParameterType
        {
            get;
        }

        public ParametrizedConversion<object, object, object> Conversion
        {
            get;
        }
    }
}

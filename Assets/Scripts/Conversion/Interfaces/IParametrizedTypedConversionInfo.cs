using System;

namespace ESparrow.Utils.Conversion.Interfaces
{
    public interface IParametrizedTypedConversionInfo : IConversionInfo
    {
        Type ParameterType
        {
            get;
        }

        ParametrizedConversion<object, object, object> Conversion
        {
            get;
        }
    }
}

using System;
using System.Linq;
using System.Reflection;
using ESparrow.Utils.Exceptions;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Conversion.Adapters
{
    public class ConstructorToTypedConversionAdapter : ToTypedConversionAdapterBase<ConstructorInfo>
    {
        public ConstructorToTypedConversionAdapter(ConstructorInfo converter) : base(converter)
        {
            
        }

        protected override object Convert(ConstructorInfo converter, object value)
        {
            return converter.Invoke(value.AsSingleEnumerable().ToArray());
        }

        protected override Type GetOriginalType(ConstructorInfo converter)
        {
            var parameters = converter.GetParameters();

            if (parameters.Length != 1)
                throw new WtfException("Count of parameters of conversion constructor must equal 1");

            var parameter = parameters.First();
            
            return parameter.ParameterType;
        }

        protected override Type GetFinalType(ConstructorInfo converter)
        {
            return converter.DeclaringType;
        }
    }
}
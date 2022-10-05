using System;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Exceptions;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Tools.Conversion.Adapters
{
    public class ConstructorToTypedConversionAdapter : ToTypedConversionAdapterBase<ConstructorInfo>
    {
        public ConstructorToTypedConversionAdapter(ConstructorInfo converter) : base(converter)
        {
            
        }

        protected override object Convert(ConstructorInfo converter, object value)
        {
            var parameter = value.AsSingleEnumerable().ToArray();
            
            var result = converter.Invoke(parameter);
            return result;
        }

        protected override Type GetOriginalType(ConstructorInfo converter)
        {
            var parameters = converter.GetParameters();

            if (parameters.Length != 1)
                throw new WtfException("Count of parameters of conversion constructor must equal 1");

            var parameter = parameters.First();

            var result = parameter.ParameterType;
            return result;
        }

        protected override Type GetFinalType(ConstructorInfo converter)
        {
            var result = converter.DeclaringType;
            return result;
        }
    }
}
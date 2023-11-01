using System;
using System.Reflection;

namespace Birdhouse.Common.Reflection.Conversions.Adapters
{
    public class MethodToTypedConversionAdapter : ToTypedConversionAdapterBase<MethodInfo>
    {
        public MethodToTypedConversionAdapter(MethodInfo converter) : base(converter)
        {
            
        }

        protected override object Convert(MethodInfo converter, object value)
        {
            var result = converter.Invoke(value, null);
            return result;
        }

        protected override Type GetOriginalType(MethodInfo converter)
        {
            var result = converter.DeclaringType;
            return result;
        }

        protected override Type GetFinalType(MethodInfo converter)
        {
            var result = converter.ReturnType;
            return result;
        }
    }
}
using System;
using System.Reflection;

namespace ESparrow.Utils.Conversion.Adapters
{
    public class MethodToTypedConversionAdapter : ToTypedConversionAdapterBase<MethodInfo>
    {
        public MethodToTypedConversionAdapter(MethodInfo converter) : base(converter)
        {
            
        }

        protected override object Convert(MethodInfo converter, object value)
        {
            return converter.Invoke(value, null);
        }

        protected override Type GetOriginalType(MethodInfo converter)
        {
            return converter.DeclaringType;
        }

        protected override Type GetFinalType(MethodInfo converter)
        {
            return converter.ReturnType;
        }
    }
}
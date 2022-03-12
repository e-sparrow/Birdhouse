using System;
using ESparrow.Utils.Reflection.Operators;

namespace ESparrow.Utils.Conversion.Adapters
{
    public class UnaryOperatorToTypedConversionAdapter : ToTypedConversionAdapterBase<UnaryOperatorInfo>
    {
        public UnaryOperatorToTypedConversionAdapter(Type original, UnaryOperatorInfo converter) : base(converter)
        {
            _original = original;
        }

        private readonly Type _original;

        protected override object Convert(UnaryOperatorInfo converter, object value)
        {
            return converter.Invoke(value);
        }

        protected override Type GetOriginalType(UnaryOperatorInfo converter)
        {
            return _original;
        }

        protected override Type GetFinalType(UnaryOperatorInfo converter)
        {
            return converter.ReturnType;
        }
    }
}
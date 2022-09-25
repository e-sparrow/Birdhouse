using System;
using Birdhouse.Common.Reflection.Operators.Interfaces;

namespace Birdhouse.Tools.Conversion.Adapters
{
    public class UnaryOperatorToTypedConversionAdapter : ToTypedConversionAdapterBase<IUnaryOperatorInfo>
    {
        public UnaryOperatorToTypedConversionAdapter(Type original, IUnaryOperatorInfo converter) : base(converter)
        {
            _original = original;
        }

        private readonly Type _original;

        protected override object Convert(IUnaryOperatorInfo converter, object value)
        {
            return converter.Invoke(value);
        }

        protected override Type GetOriginalType(IUnaryOperatorInfo converter)
        {
            return _original;
        }

        protected override Type GetFinalType(IUnaryOperatorInfo converter)
        {
            return converter.ReturnType;
        }
    }
}
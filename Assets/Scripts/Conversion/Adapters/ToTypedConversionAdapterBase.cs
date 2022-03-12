using System;
using ESparrow.Utils.Conversion.Interfaces;

namespace ESparrow.Utils.Conversion.Adapters
{
    public abstract class ToTypedConversionAdapterBase<T> : ITypedConversion
    {
        protected ToTypedConversionAdapterBase(T converter)
        {
            _converter = converter;
        }

        private readonly T _converter;

        protected abstract object Convert(T converter, object value);
        
        protected abstract Type GetOriginalType(T converter);
        protected abstract Type GetFinalType(T converter);
        
        public object Convert(object value)
        {
            return Convert(_converter, value);
        }

        public ITypedConversionInfo Info => new TypedConversionInfo(GetOriginalType(_converter), GetFinalType(_converter), Convert);
    }
}
using System;
using Birdhouse.Common.Reflection.Conversions.Interfaces;

namespace Birdhouse.Common.Reflection.Conversions.Adapters
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
            var result = Convert(_converter, value);
            return result;
        }
        
        private ITypedConversionInfo GetInfo()
        {
            var original = GetOriginalType(_converter);
            var final = GetFinalType(_converter);
            
            var result = new TypedConversionInfo(original, final, Convert);
            return result;
        }

        public ITypedConversionInfo Info => GetInfo();
    }
}
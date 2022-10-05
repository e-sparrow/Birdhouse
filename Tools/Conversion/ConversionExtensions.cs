using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Conversion.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Conversion
{
    public static class ConversionExtensions
    {
        public static IDisposable Register(this ITypedConversionInfo self)
        {
            var result = ConversionHelper.RegisterConversionInfo(self);
            return result;
        }

        public static IDisposable Register(this ITypedConversion self)
        {
            var result = ConversionHelper.RegisterConversion(self);
            return result;
        }

        public static IDisposable Register<TFrom, TTo>(this ISpecificTypedConversion<TFrom, TTo> self)
        {
            var result = ConversionHelper.RegisterSpecificTypedConversion(self);
            return result;
        }

        public static ITypedConversion NonSpecific<TFrom, TTo>(this ISpecificTypedConversion<TFrom, TTo> self)
        {
            var original = typeof(TFrom);
            var final = typeof(TTo);
            
            var info = new TypedConversionInfo(original, final, ConvertInternal);
            
            var conversion = new TypedConversion(info);
            return conversion;

            object ConvertInternal(object value)
            {
                var result = self.Convert((TFrom) value);
                return result;
            }
        }
        
        public static bool TryConvert<TFrom, TTo>(this TFrom self, out TTo result)
        {
            var canConvert = ConversionHelper.TryConvert(self, out result);
            return canConvert;
        }

        public static TTo Convert<TFrom, TTo>(this TFrom self)
        {
            var canConvert = self.TryConvert<TFrom, TTo>(out var result);
            if (canConvert)
            {
                return result;
            }

            throw new ArgumentException($"{"Can't".WithColor(Color.red).Bold()} convert {typeof(TFrom)} to {typeof(TTo)}");
        }

        public static TBase Base<TInheritor, TBase>(this TInheritor self) where TInheritor : TBase
        {
            return self;
        }

        public static TInheritor Inheritor<TBase, TInheritor>(this TBase self) where TInheritor : TBase
        {
            if (self is TInheritor inheritor)
            {
                return inheritor;
            }

            throw new ArgumentException($"{typeof(TInheritor)} is {"not".WithColor(Color.red).Bold()} inherits from {typeof(TBase)}!");
        }
    }
}
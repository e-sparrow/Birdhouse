using System;
using System.Collections;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Conversion.Adapters;
using Birdhouse.Tools.Conversion.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Conversion
{
    public static class ConversionExtensions
    {
        public static IDisposable Register(this ITypedConversion self)
        {
            var result = ConversionHelper.RegisterTypedConversion(self);
            return result;
        }

        public static IDisposable Register<TFrom, TTo>(this ISpecificTypedConversion<TFrom, TTo> self)
        {
            var result = ConversionHelper.RegisterSpecificTypedConversion(self);
            return result;
        }

        public static ITypedConversion IsNotSpecific<TFrom, TTo>(this ISpecificTypedConversion<TFrom, TTo> self)
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

        public static IReversibleSpecificTypedConversion<TFrom, TTo> Combine<TFrom, TTo>
        (
            this ISpecificTypedConversion<TFrom, TTo> self,
            ISpecificTypedConversion<TTo, TFrom> back)
        {
            var result = new SpecificToReversibleDataConversionAdapter<TFrom, TTo>(self, back);
            return result;
        }

        public static IReversibleSpecificTypedConversion<TTo, TFrom> Swap<TFrom, TTo>
            (this IReversibleSpecificTypedConversion<TFrom, TTo> self)
        {
            var result = new ReversibleDataConversionSwapper<TFrom, TTo>(self);
            return result;
        }

        public static IEnumerable<ITypedConversion> Split<TFrom, TTo>
            (this IReversibleSpecificTypedConversion<TFrom, TTo> self)
        {
            var originalType = typeof(TFrom);
            var finalType = typeof(TTo);

            var firstInfo = new TypedConversionInfo(originalType, finalType, ConvertToFinal);
            var secondInfo = new TypedConversionInfo(finalType, originalType, ConvertToOriginal);

            var first = new TypedConversion(firstInfo);
            var second = new TypedConversion(secondInfo);

            var result = first.ConcatWith(second);
            return result;

            object ConvertToFinal(object value)
            {
                var fromValue = (TFrom) value;
                
                var converted = self.Convert(fromValue);
                return converted;
            }

            object ConvertToOriginal(object value)
            {
                var toValue = (TTo) value;
                
                var converted = self.Convert(toValue);
                return converted;
            }
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
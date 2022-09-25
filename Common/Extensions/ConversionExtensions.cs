using System;
using Birdhouse.Common.Helpers;

namespace Birdhouse.Common.Extensions
{
    public static class ConversionExtensions
    {
        public static TTo ConvertTo<TFrom, TTo>(this TFrom self)
        {
            if (ConversionHelper.TryConvert<TFrom, TTo>(self, out var value))
            {
                return value;
            }
            
            throw new ArgumentException($"Can't convert value from {typeof(TFrom).Name} type to {typeof(TTo).Name}");
        }

        public static TBase Base<TInheritor, TBase>(this TInheritor self) where TInheritor : TBase
        {
            return self;
        }

        public static TInheritor Inheritor<TBase, TInheritor>(this TBase self) where TInheritor : TBase
        {
            return self is TInheritor inheritor ? inheritor : default;
        }
    }
}

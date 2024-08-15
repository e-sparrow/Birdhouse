using System;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Abstractions.Factories
{
    public static class FactoryExtensions
    {
        public static IFactory ToTypelessFactory<TIn, TOut>(this IFactory<TIn, TOut> self)
        {
            var result = new Factory(new Func<TIn, TOut>(self.Create).AsTypeless());
            return result;
        }
        
        public static IFactory ToTypelessFactory<TIn1, TIn2, TOut>(this IFactory<TIn1, TIn2, TOut> self)
        {
            var result = new Factory(new Func<TIn1, TIn2, TOut>(self.Create).AsTypeless());
            return result;
        }
        
        public static IFactory ToTypelessFactory<TIn1, TIn2, TIn3, TOut>(this IFactory<TIn1, TIn2, TIn3, TOut> self)
        {
            var result = new Factory(new Func<TIn1, TIn2, TIn3, TOut>(self.Create).AsTypeless());
            return result;
        }
    }
}
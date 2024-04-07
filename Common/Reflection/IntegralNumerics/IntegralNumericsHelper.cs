using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.IntegralNumerics.Enums;

namespace Birdhouse.Common.Reflection.IntegralNumerics
{
    public static class IntegralNumericsHelper
    {
        private static readonly Lazy<IDictionary<EIntegralNumericType, Type>> LazyTypesDictionary 
            = new Lazy<IDictionary<EIntegralNumericType, Type>>(GetTypesDictionary);
        
        public static IDictionary<EIntegralNumericType, Type> TypesDictionary => LazyTypesDictionary.Value;

        public static Type GetIntegralNumericType(EIntegralNumericType numeric)
        {
            var result = LazyTypesDictionary.Value[numeric];
            return result;
        }

        public static bool TryGetIntegralNumeric(Type type, out EIntegralNumericType numeric)
        {
            numeric = default;
            
            var isSuccess = LazyTypesDictionary.Value.TryGetFirst(pair => pair.Value == type, out var result);
            if (isSuccess)
            {
                numeric = result.Key;
            }

            return isSuccess;
        }
        
        private static IDictionary<EIntegralNumericType, Type> GetTypesDictionary()
        {
            var result = new Dictionary<EIntegralNumericType, Type>()
            {
                { EIntegralNumericType.SByte, typeof(sbyte) },
                { EIntegralNumericType.Byte, typeof(byte) },
                { EIntegralNumericType.Short , typeof(short) },
                { EIntegralNumericType.UShort, typeof(ushort) },
                { EIntegralNumericType.Int, typeof(int) },
                { EIntegralNumericType.UInt, typeof(uint) },
                { EIntegralNumericType.Long, typeof(long) },
                { EIntegralNumericType.ULong, typeof(ulong) },
                { EIntegralNumericType.IntPtr, typeof(IntPtr) },
                { EIntegralNumericType.UIntPtr, typeof(UIntPtr) }
                
            };

            return result;
        }
    }
}
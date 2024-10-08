﻿using System;
using Birdhouse.Common.Reflection.Misc.Enums;

namespace Birdhouse.Common.Reflection.Misc
{
    public static class IntegralNumericExtensions
    {
        public static Type AsType(this EIntegralNumericType self)
        {
            var result = IntegralNumericsHelper.GetIntegralNumericType(self);
            return result;
        }
        
        public static bool TryGetIntegralNumericEnum(this Type self, out EIntegralNumericType result)
        {
            var isSuccess = IntegralNumericsHelper.TryGetIntegralNumeric(self, out result);
            return isSuccess;
        }
    }
}
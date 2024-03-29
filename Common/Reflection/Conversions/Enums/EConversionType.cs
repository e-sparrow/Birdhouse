﻿using System;

namespace Birdhouse.Common.Reflection.Conversions.Enums
{
    [Flags]
    public enum EConversionType
    {
        Marked = 1,
        ImplicitOperator = 2,
        ExplicitOperator = 4,
        Constructor = 8,
        Method = 16,
        
        All = Marked | ImplicitOperator | ExplicitOperator | Constructor | Method
    }
}
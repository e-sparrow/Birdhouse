using System;
using Birdhouse.Tools.Conversion.Interfaces;

namespace Birdhouse.Tools.Conversion
{
    public readonly struct TypedConversionInfo : ITypedConversionInfo
    {
        public TypedConversionInfo(Type originalType, Type finalType, Conversion conversion)
        {
            OriginalType = originalType;
            FinalType = finalType;
            Conversion = conversion;
        }

        public Type OriginalType
        {
            get;
        }

        public Type FinalType
        {
            get;
        }

        public Conversion Conversion
        {
            get;
        }
    }
}

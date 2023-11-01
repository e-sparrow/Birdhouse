using System;

namespace Birdhouse.Common.Reflection.Conversions.Interfaces
{
    public interface IConversionInfo
    {
        Type OriginalType
        {
            get;
        }

        Type FinalType
        {
            get;
        }
    }
}

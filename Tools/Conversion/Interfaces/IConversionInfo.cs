using System;

namespace Birdhouse.Tools.Conversion.Interfaces
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

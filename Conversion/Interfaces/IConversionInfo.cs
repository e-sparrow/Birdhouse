using System;

namespace ESparrow.Utils.Conversion.Interfaces
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

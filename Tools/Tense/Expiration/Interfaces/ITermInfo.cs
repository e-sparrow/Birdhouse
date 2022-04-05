using System;
using ESparrow.Utils.Tools.Tense.Expiration.Enums;

namespace ESparrow.Utils.Tools.Tense.Expiration.Interfaces
{
    public interface ITermInfo
    {
        ETermType Type
        {
            get;
        }
        
        DateTime AbsoluteExpiration
        {
            get;
        }

        TimeSpan SlidingExpiration
        {
            get;
        }
    }
}
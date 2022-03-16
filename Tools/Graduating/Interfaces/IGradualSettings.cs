using System;
using ESparrow.Utils.Tools.Easing.Interfaces;

namespace ESparrow.Utils.Tools.Graduating.Interfaces
{
    public interface IGradualSettings
    {
        Action<float> Action
        {
            get;
        }
        
        TimeSpan Duration
        {
            get;
        }

        IEase Ease
        {
            get;
        }
    }
}

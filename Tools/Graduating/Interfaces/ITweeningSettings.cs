using System;
using ESparrow.Utils.Tools.Easing.Interfaces;

namespace ESparrow.Utils.Tools.Graduating.Interfaces
{
    public interface ITweeningSettings
    {

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
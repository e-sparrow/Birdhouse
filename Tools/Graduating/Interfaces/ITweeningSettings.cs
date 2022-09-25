using System;
using Birdhouse.Tools.Easing.Interfaces;

namespace Birdhouse.Tools.Graduating.Interfaces
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
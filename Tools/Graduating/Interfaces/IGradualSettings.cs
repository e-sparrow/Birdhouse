using System;
using Birdhouse.Tools.Easing.Interfaces;

namespace Birdhouse.Tools.Graduating.Interfaces
{
    public interface IGradualSettings : ITweeningSettings
    {
        Action<float> Action
        {
            get;
        }
    }
}

using System;
using Birdhouse.Tools.Easing.Interfaces;
using Birdhouse.Tools.Graduating.Interfaces;

namespace Birdhouse.Tools.Graduating
{
    public readonly struct GradualSettings : IGradualSettings
    {
        public GradualSettings(Action<float> action, TimeSpan duration, IEase ease = null)
        {
            Action = action;
            Duration = duration;
            Ease = ease;
        }
        
        public GradualSettings(Action<float> action, float duration, IEase ease = null)
            : this(action, TimeSpan.FromSeconds(duration), ease)
        {
            
        }

        public GradualSettings(Action<float> action, ITweeningSettings settings) 
            : this(action, settings.Duration, settings.Ease)
        {
            
        }

        public Action<float> Action
        {
            get;
        }

        public TimeSpan Duration
        {
            get;
        }

        public IEase Ease
        {
            get;
        }
    }
}


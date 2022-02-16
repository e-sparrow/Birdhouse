using System;
using ESparrow.Utils.Tools.Eases.Interfaces;
using ESparrow.Utils.Tools.Graduating.Interfaces;

namespace ESparrow.Utils.Tools.Graduating
{
    public readonly struct GradualSettings : IGradualSettings
    {
        public GradualSettings(Action<float> action, TimeSpan duration, IEase ease = null)
        {
            Action = action;
            Duration = duration;
            Ease = ease;
        }
        
        public GradualSettings(Action<float> action, float duration, IEase ease = null) : this(action, TimeSpan.FromSeconds(duration), ease)
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


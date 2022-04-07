using System;
using ESparrow.Utils.Tools.Easing;
using ESparrow.Utils.Tools.Easing.Interfaces;
using ESparrow.Utils.Tools.Graduating.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Graduating
{
    [Serializable]
    public class SerializableTweeningSettings : ITweeningSettings
    {
        [SerializeField] private float duration;
        [SerializeField] private AnimationCurve curve;

        public TimeSpan Duration => TimeSpan.FromSeconds(duration);
        public IEase Ease => new Ease(curve);
    }
}
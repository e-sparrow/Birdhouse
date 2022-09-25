using System;
using Birdhouse.Tools.Easing;
using Birdhouse.Tools.Easing.Interfaces;
using Birdhouse.Tools.Graduating.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Graduating
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
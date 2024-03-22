﻿using Birdhouse.Abstractions.Misc.Interfaces;
using Birdhouse.Abstractions.Renewables.Interfaces;
using Birdhouse.Tools.Easing;
using Birdhouse.Tools.Easing.Interfaces;
using Birdhouse.Tools.Ticks;
using Birdhouse.Tools.Tweening.Abstractions;

namespace Birdhouse.Tools.Tweening
{
    public abstract class TweenerBase
        : TickFlowBase, ITweener, IProgressive
    {
        protected TweenerBase(float startValue, float duration, bool resetEase = false, IEase ease = null)
        {
            ease ??= new Ease();
            
            _startValue = startValue;
            _currentValue = startValue;
            
            _ease = ease;
        }

        private float _startValue;
        private float _currentValue;
        private float _targetValue;
        
        private IEase _ease;

        public bool IsPaused
        {
            get;
            private set;
        }

        public float TargetValue
        {
            get => _targetValue;
            set => ChangeTargetValue(value);
        }

        protected override void Tick(float deltaTime)
        {
            
        }

        public void SetPaused(bool isPaused)
        {
            throw new System.NotImplementedException();
        }

        private void ChangeTargetValue(float value)
        {
            _startValue = _currentValue;
            _targetValue = value;
        }

        public float Progress { get; set; }
    }
}
using Birdhouse.Abstractions.Misc.Interfaces;
using Birdhouse.Abstractions.Renewables.Interfaces;
using Birdhouse.Tools.Easing;
using Birdhouse.Tools.Easing.Interfaces;
using Birdhouse.Tools.Ticks;
using Birdhouse.Tools.Tweening.Abstractions;

namespace Birdhouse.Tools.Tweening
{
    public abstract class TweenerBase
        : TickFlowBase, ITweener
    {
        protected TweenerBase(IProgressive target, float startValue, float duration, bool resetEase = false, IEase ease = null)
        {
            ease ??= new Ease();

            _target = target;
            
            _startValue = startValue;
            _currentValue = startValue;
            
            _ease = ease;
        }

        private readonly IProgressive _target;

        private float _startValue;
        private float _currentValue;
        private float _targetValue;
        
        private IEase _ease;

        public bool IsPaused
        {
            get;
            set;
        }

        public float Progress
        {
            get; 
            set;
        }

        public float TargetValue
        {
            get => _targetValue;
            set => ChangeTargetValue(value);
        }

        protected override void Tick(float deltaTime)
        {
            
        }

        private void ChangeTargetValue(float value)
        {
            _startValue = _currentValue;
            _targetValue = value;
        }
    }
}
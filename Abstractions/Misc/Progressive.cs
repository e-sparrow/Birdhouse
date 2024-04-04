using System;
using Birdhouse.Abstractions.Misc.Interfaces;

namespace Birdhouse.Abstractions.Misc
{
    public class Progressive
        : IProgressive
    {
        public Progressive(Action<float> onChangeValue, float initialValue = 0f)
        {
            _onChangeValue = onChangeValue;
            _value = initialValue;
        }

        private readonly Action<float> _onChangeValue;
        
        private float _value;
        
        public float Progress
        {
            get => _value;
            set
            {
                _value = value;
                _onChangeValue.Invoke(_value);
            }
        }
    }
}
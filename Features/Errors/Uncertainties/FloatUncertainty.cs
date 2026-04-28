namespace Birdhouse.Features.Errors
{
    public sealed class FloatUncertainty
        : IUncertainty<float>
    {
        public FloatUncertainty(IErrorProvider approximator, float origin, float negativeError, float positiveError, bool isNegativePercent, bool isPositivePercent)
        {
            _approximator = approximator;
            
            _origin = origin;
            _negativeError = negativeError;
            _positiveError = positiveError;
            _isNegativePercent = isNegativePercent;
            _isPositivePercent = isPositivePercent;
        }

        private readonly IErrorProvider _approximator;
        
        private readonly float _origin;
        private readonly float _negativeError;
        private readonly float _positiveError;
        private readonly bool _isNegativePercent;
        private readonly bool _isPositivePercent;
        
        public float Perturb()
        {
            var negativeAmount = _isNegativePercent ? _origin * _negativeError / 100f : _negativeError;
            var positiveAmount = _isPositivePercent ? _origin * _positiveError / 100f : _positiveError;
            
            var value = _approximator.GetNext();
            if (value < 0f) value *= negativeAmount;
            else value *= positiveAmount;

            return _origin + value;
        }
    }
}
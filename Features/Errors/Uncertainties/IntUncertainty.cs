using System.Threading;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    public sealed class IntUncertainty
        : IUncertainty<int>
    {
        public IntUncertainty(IErrorProvider approximator, int origin, int negativeError, int positiveError, bool isNegativePercent, bool isPositivePercent)
        {
            _approximator = approximator;
            
            _origin = origin;
            _negativeError = negativeError;
            _positiveError = positiveError;
            _isNegativePercent = isNegativePercent;
            _isPositivePercent = isPositivePercent;
        }

        private static readonly ThreadLocal<Random> ThreadLocalRandom 
            = new ThreadLocal<Random>(() => new Random());

        private readonly IErrorProvider _approximator;
        
        private readonly int _origin;
        private readonly int _negativeError;
        private readonly int _positiveError;
        private readonly bool _isNegativePercent;
        private readonly bool _isPositivePercent;
        
        public int Perturb()
        {
            var negativeAmount = _isNegativePercent ? _origin * _negativeError / 100f : _negativeError;
            var positiveAmount = _isPositivePercent ? _origin * _positiveError / 100f : _positiveError;
            
            var value = _approximator.GetNext();
            if (value < 0f) value *= negativeAmount;
            else value *= positiveAmount;

            return _origin + Mathf.RoundToInt(value);
        }
    }
}
using Birdhouse.Common.Randomness;
using Birdhouse.Common.Threading;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    public sealed class ExponentialErrorProvider
        : IErrorProvider
    {
        public ExponentialErrorProvider(float lambda, Random random = null)
        {
            random ??= GlobalThreadLocal<Random>.Value;

            _lambda = lambda;
            _random = random;
        }

        private readonly float _lambda;
        private readonly Random _random;
        
        public float GetNext()
        {
            var value = 1f - Mathf.Pow(_random.NextFloat(), _lambda); // 0..1, пик в 0
            return _random.NextFloat() < 0.5f ? -value : value;
        }
    }
}
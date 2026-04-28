using Birdhouse.Common.Randomness;
using Birdhouse.Common.Threading;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    public sealed class CustomErrorProvider
        : IErrorProvider
    {
        public CustomErrorProvider(AnimationCurve curve, Random random = null)
        {
            random ??= GlobalThreadLocal<Random>.Value;

            _curve = curve;
            _random = random;
        }

        private readonly AnimationCurve _curve;
        private readonly Random _random;
        
        public float GetNext()
        {
            var value = _curve.Evaluate(_random.NextFloat());
            return Mathf.Clamp(value * 2f - 1f, -1f, 1f);
        }
    }
}
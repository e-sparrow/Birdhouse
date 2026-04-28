using Birdhouse.Common.Threading;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    public sealed class TriangleErrorProvider
        : IErrorProvider
    {
        public TriangleErrorProvider(float peak, Random random = null)
        {
            random ??= GlobalThreadLocal<Random>.Value;

            _peak = peak;
            _random = random;
        }

        private readonly float _peak;
        private readonly Random _random;
        
        public float GetNext()
        {
            var value = (float) _random.NextDouble();
            var peakNorm = (_peak + 1f) / 2f; // -1..1 -> 0..1
            
            if (value < peakNorm) return Mathf.Sqrt(value * peakNorm) * 2f - 1f;
            else return (1f - Mathf.Sqrt((1f - value) * (1f - peakNorm))) * 2f - 1f;
        }
    }
}
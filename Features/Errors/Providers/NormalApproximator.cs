using Birdhouse.Common.Threading;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    public sealed class NormalErrorProvider
        : IErrorProvider
    {
        public NormalErrorProvider(float sigma, Random random = null)
        {
            random ??= GlobalThreadLocal<Random>.Value;
            
            _sigma = sigma;
            _random = random;
        }

        private readonly float _sigma;
        private readonly Random _random;
        
        public float GetNext()
        {
            var u1 = 1f - (float) _random.NextDouble();
            var u2 = 1f - (float) _random.NextDouble();
            var normal = Mathf.Sqrt(-2f * Mathf.Log(u1)) * Mathf.Cos(2f * Mathf.PI * u2);
            return Mathf.Clamp(normal * _sigma, -1f, 1f);
        }
    }
}
using System;
using Birdhouse.Common.Randomness;
using Birdhouse.Common.Threading;

namespace Birdhouse.Features.Errors
{
    public sealed class UniformErrorProvider
        : IErrorProvider
    {
        // TODO: Move Random to base class
        public UniformErrorProvider(Random random = null)
        {
            random ??= GlobalThreadLocal<Random>.Value;
            _random = random;
        }

        private readonly Random _random;

        public float GetNext() => _random.NextFloat() * 2f - 1f;
    }
}
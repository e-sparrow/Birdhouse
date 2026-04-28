using System;
using Birdhouse.Common.Randomness;
using Birdhouse.Common.Threading;

namespace Birdhouse.Features.Errors
{
    public sealed class BoolUncertainty
        : IUncertainty<bool>
    {
        public BoolUncertainty(float probability, Random random = null)
        {
            random ??= GlobalThreadLocal<Random>.Value;
            
            _probability = probability;
            _random = random;
        }

        private readonly float _probability;
        private readonly Random _random;

        public bool Perturb() => _random.NextFloat() <= _probability;
    }
}
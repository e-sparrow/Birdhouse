using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public sealed class Vector2Uncertainty
        : IUncertainty<Vector2>
    {
        public Vector2Uncertainty(IUncertainty<float> x, IUncertainty<float> y)
        {
            _x = x;
            _y = y;
        }

        private readonly IUncertainty<float> _x;
        private readonly IUncertainty<float> _y;

        public Vector2 Perturb() => new Vector2(_x.Perturb(), _y.Perturb());
    }
}
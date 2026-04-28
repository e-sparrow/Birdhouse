using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public class Vector3Uncertainty
        : IUncertainty<Vector3>
    {
        public Vector3Uncertainty(IUncertainty<float> x, IUncertainty<float> y, IUncertainty<float> z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        private readonly IUncertainty<float> _x;
        private readonly IUncertainty<float> _y;
        private readonly IUncertainty<float> _z;

        public Vector3 Perturb() => new Vector3(_x.Perturb(), _y.Perturb(), _z.Perturb());
    }
}
using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public sealed class Vector4Uncertainty
        : IUncertainty<Vector4>
    {
        public Vector4Uncertainty(IUncertainty<float> x, IUncertainty<float> y, IUncertainty<float> z, IUncertainty<float> w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        private readonly IUncertainty<float> _x;
        private readonly IUncertainty<float> _y;
        private readonly IUncertainty<float> _z;
        private readonly IUncertainty<float> _w;

        public Vector4 Perturb() => new Vector4(_x.Perturb(), _y.Perturb(), _z.Perturb(), _w.Perturb());
    }
}
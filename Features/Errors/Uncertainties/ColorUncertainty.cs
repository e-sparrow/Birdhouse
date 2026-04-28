using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public sealed class ColorUncertainty
        : IUncertainty<Color>
    {
        public ColorUncertainty(IUncertainty<float> r, IUncertainty<float> g, IUncertainty<float> b, IUncertainty<float> a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        private readonly IUncertainty<float> _r;
        private readonly IUncertainty<float> _g;
        private readonly IUncertainty<float> _b;
        private readonly IUncertainty<float> _a;

        public Color Perturb() => new Color(_r.Perturb(), _g.Perturb(), _b.Perturb(), _a.Perturb());
    }
}
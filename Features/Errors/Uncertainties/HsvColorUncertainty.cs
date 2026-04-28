using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public sealed class HsvColorUncertainty
        : IUncertainty<Color>
    {
        public HsvColorUncertainty(IUncertainty<float> h, IUncertainty<float> s, IUncertainty<float> v)
        {
            _h = h;
            _s = s;
            _v = v;
        }

        private readonly IUncertainty<float> _h;
        private readonly IUncertainty<float> _s;
        private readonly IUncertainty<float> _v;

        public Color Perturb() => Color.HSVToRGB(_h.Perturb(), _s.Perturb(), _v.Perturb());
    }
}
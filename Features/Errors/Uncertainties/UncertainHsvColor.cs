using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainHsvColor
        : SerializedUncertainValueBase<Color>
    {
        [SerializeField] private UncertainFloat h;
        [SerializeField] private UncertainFloat s;
        [SerializeField] private UncertainFloat v;

        public override IUncertainty<Color> ToUncertainty(Random random = null)
            => new HsvColorUncertainty(h.ToUncertainty(random), s.ToUncertainty(random), v.ToUncertainty(random));
        
        public static implicit operator UncertainHsvColor(Color color)
        {
            Color.RGBToHSV(color, out var h, out var s, out var v);
            return new UncertainHsvColor { h = h, s = s, v = v };
        }
    }
}
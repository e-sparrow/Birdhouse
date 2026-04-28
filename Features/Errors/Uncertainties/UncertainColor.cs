using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainColor
        : SerializedUncertainValueBase<Color>
    {
        [SerializeField] private UncertainFloat r;
        [SerializeField] private UncertainFloat g;
        [SerializeField] private UncertainFloat b;
        [SerializeField] private UncertainFloat a;

        public override IUncertainty<Color> ToUncertainty(Random random = null) 
            => new ColorUncertainty(r.ToUncertainty(random), g.ToUncertainty(random), b.ToUncertainty(random), a.ToUncertainty(random));

        public static implicit operator UncertainColor(Color color) 
            => new UncertainColor() { r = color.r, g = color.g, b = color.b, a = color.a };
    }
}
using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainVector4
        : SerializedUncertainValueBase<Vector4>
    {
        [SerializeField] private UncertainFloat x;
        [SerializeField] private UncertainFloat y;
        [SerializeField] private UncertainFloat z;
        [SerializeField] private UncertainFloat w;

        public override IUncertainty<Vector4> ToUncertainty(Random random = null)
            => new Vector4Uncertainty(x.ToUncertainty(random), y.ToUncertainty(random), z.ToUncertainty(random), w.ToUncertainty(random));

        public static implicit operator UncertainVector4(Vector4 value)
            => new UncertainVector4() { x = value.x, y = value.y, z = value.z, w = value.w };
    }
}
using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public class UncertainVector3
        : SerializedUncertainValueBase<Vector3>
    {
        [SerializeField] private UncertainFloat x;
        [SerializeField] private UncertainFloat y;
        [SerializeField] private UncertainFloat z;

        public override IUncertainty<Vector3> ToUncertainty(Random random = null)
            => new Vector3Uncertainty(x.ToUncertainty(random), y.ToUncertainty(random), z.ToUncertainty(random));
    }
}
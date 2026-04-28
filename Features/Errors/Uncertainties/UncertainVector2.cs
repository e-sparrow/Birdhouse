using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainVector2
        : SerializedUncertainValueBase<Vector2>
    {
        [SerializeField] private UncertainFloat x;
        [SerializeField] private UncertainFloat y;

        public override IUncertainty<Vector2> ToUncertainty(Random random = null) 
            => new Vector2Uncertainty(x.ToUncertainty(random), y.ToUncertainty(random));
    }
}
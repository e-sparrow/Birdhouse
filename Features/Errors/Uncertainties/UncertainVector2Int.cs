using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainVector2Int
        : SerializedUncertainValueBase<Vector2Int>
    {
        [SerializeField] private UncertainInt x;
        [SerializeField] private UncertainInt y;

        public override IUncertainty<Vector2Int> ToUncertainty(Random random = null)
            => new Vector2IntUncertainty(x.ToUncertainty(random), y.ToUncertainty(random));
    }
}
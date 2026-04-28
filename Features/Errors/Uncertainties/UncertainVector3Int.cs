using System;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainVector3Int
        : SerializedUncertainValueBase<Vector3Int>
    {
        [SerializeField] private UncertainInt x;
        [SerializeField] private UncertainInt y;
        [SerializeField] private UncertainInt z;

        public override IUncertainty<Vector3Int> ToUncertainty(Random random = null) 
            => new Vector3IntUncertainty(x.ToUncertainty(random), y.ToUncertainty(random), z.ToUncertainty(random));
    }
}
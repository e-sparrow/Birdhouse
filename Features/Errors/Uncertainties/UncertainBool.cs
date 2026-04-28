using System;
using Birdhouse.Features.Errors;
using UnityEngine;
using Random = System.Random;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public sealed class UncertainBool
        : SerializedUncertainValueBase<bool>
    {
        [Range(0f, 1f)]
        [SerializeField] private float probability;

        public override IUncertainty<bool> ToUncertainty(Random random = null) 
            => new BoolUncertainty(probability, random);

        public static implicit operator UncertainBool(bool value) 
            => new UncertainBool() { probability = value ? 1f : 0f };
    }
}
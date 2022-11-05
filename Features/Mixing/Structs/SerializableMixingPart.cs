using System;
using Birdhouse.Features.Mixing.Interfaces;
using UnityEngine;

namespace Birdhouse.Features.Mixing.Structs
{
    [Serializable]
    public struct SerializableMixingPart<T> : IMixingPart<T>
    {
        [SerializeField] private T value;
        [SerializeField] private float proportion;

        public T Value => value;
        public float Proportion => proportion;
    }
}
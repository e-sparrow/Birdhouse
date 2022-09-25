using System;
using Birdhouse.Mechanics.Mixing.Interfaces;
using UnityEngine;

namespace Birdhouse.Mechanics.Mixing.Structs
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
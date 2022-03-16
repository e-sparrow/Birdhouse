using System;
using ESparrow.Utils.Tools.Interpolation.Mixing.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Mechanics.Mixing.Structs
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
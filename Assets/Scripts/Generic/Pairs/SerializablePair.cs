using System;
using ESparrow.Utils.Generic.Pairs.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generic.Pairs
{
    [Serializable]
    public struct SerializablePair<T1, T2> : IPair<T1, T2>
    {
        [SerializeField] private T1 key;
        [SerializeField] private T2 value;

        public T1 Key => key;
        public T2 Value => value;
    }
}
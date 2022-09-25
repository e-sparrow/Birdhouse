using System;
using Birdhouse.Common.Generic.Pairs.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Generic.Pairs
{
    [Serializable]
    public struct SerializablePair<TKey, TValue> : IPair<TKey, TValue>
    {
        [SerializeField] private TKey key;
        [SerializeField] private TValue value;

        public TKey Key => key;
        public TValue Value => value;
    }
}
using System.Collections.Generic;
using Birdhouse.Common.Generic.Pairs;
using Birdhouse.Common.Generic.Pairs.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Storages.Scriptable
{
    public class ScriptableStorageGeneric<TKey, TValue> : ScriptableStorageBase<TKey, TValue>
    {
        [SerializeField] private List<SerializablePair<TKey, TValue>> data;

        protected override bool IsFit(TKey key, IPair<TKey, TValue> pair)
        {
            return pair.Key.Equals(key);
        }

        protected override IEnumerable<IPair<TKey, TValue>> Data => data as IEnumerable<IPair<TKey, TValue>>;
    }
}
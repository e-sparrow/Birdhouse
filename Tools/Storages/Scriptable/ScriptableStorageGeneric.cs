using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Generic.Pairs;
using Birdhouse.Common.Generic.Pairs.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Storages.Scriptable
{
    public class ScriptableStorageGeneric<TKey, TValue> : ScriptableStorageBase<TKey, TValue>
    {
        [SerializeField] private List<SerializablePair<TKey, TValue>> data;
        
        public override TValue GetValue(TKey key)
        {
            var result = data
                .First(value => value.Key.Equals(key))
                .Value;

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Generic.Pairs;
using UnityEngine;

namespace Birdhouse.Tools.Storages.Scriptable
{
    public abstract class ScriptableStorageGenericBase<TKey, TValue> 
        : ScriptableStorageBase<TKey, TValue>
    {
        [SerializeField] private List<SerializablePair<TKey, TValue>> data;

        protected Lazy<IReadOnlyDictionary<TKey, TValue>> Dictionary 
            => new Lazy<IReadOnlyDictionary<TKey, TValue>>(CreateDictionary);

        public override TValue GetValue(TKey key)
        {
            var result = Dictionary.Value[key];
            return result;
        }
        
        private IReadOnlyDictionary<TKey, TValue> CreateDictionary()
        {
            var result = data.ToDictionary(value => value.Key, value => value.Value);
            return result;
        }
    }
}
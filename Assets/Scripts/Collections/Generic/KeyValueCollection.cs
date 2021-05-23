using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Collections.Generic
{
    [Serializable]
    public class KeyValueCollection<TKey, TValue> : IEnumerable
    {
        public KeyValueCollection()
        {
            _pairs = new List<KeyValuePair>();
        }

        public TValue this[TKey key]
        {
            get => GetPairByKey(key).value;
            set => GetPairByKey(key).value = value;
        }

        [SerializeField] private List<KeyValuePair> _pairs;

        private KeyValuePair GetPairByKey(TKey key)
        {
            return _pairs.FirstOrDefault(value => value.key.Equals(key));
        }

        public IEnumerator GetEnumerator()
        {
            return _pairs.GetEnumerator();
        }

        [Serializable]
        protected class KeyValuePair
        {
            [SerializeField] [HideInInspector] private string name;

            public TKey key;
            public TValue value;

            public KeyValuePair(TKey key)
            {
                this.key = key;
                name = key.ToString();
            }
        }
    }
}

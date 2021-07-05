using System;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Collections.Generic
{
    [Serializable]
    public sealed class EnumValueCollection<TEnum, TValue> : KeyValueCollection<TEnum, TValue> where TEnum : Enum
    {
        [NonReorderable]
        [SerializeField] new private List<EnumValuePair> _pairs;

        public EnumValueCollection()
        {
            int count = EnumsHelper<TEnum>.GetCount();

            _pairs = new List<EnumValuePair>();
            for (int i = 0; i < count; i++)
            {
                _pairs[i] = new EnumValuePair(EnumsHelper<TEnum>.GetByIndex(i));
            }
        }

        [Serializable]
        private sealed class EnumValuePair : KeyValuePair
        {
            [SerializeField] [HideInInspector] private string name;

            public EnumValuePair(TEnum key, TValue value = default) : base(key, value)
            {
                name = key.ToString();
            }
        }
    }
}

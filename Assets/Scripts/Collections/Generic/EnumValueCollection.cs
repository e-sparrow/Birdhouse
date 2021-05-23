using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Collections.Generic
{
    [Serializable]
    public sealed class EnumValueCollection<TEnum, TValue> : KeyValueCollection<TEnum, TValue> where TEnum : Enum
    {
        public EnumValueCollection()
        {
            int count = EnumsHelper.GetCount<TEnum>();

            _pairs = new List<EnumValuePair>();
            for (int i = 0; i < count; i++)
            {
                _pairs[i] = new EnumValuePair(EnumsHelper.GetByIndex<TEnum>(i));
            }
        }

        public TValue this[TEnum @enum]
        {
            get => GetPairByEnum(@enum).value;
            set => GetPairByEnum(@enum).value = value;
        }
        
        [SerializeField] private List<EnumValuePair> _pairs;

        private EnumValuePair GetPairByEnum(TEnum @enum)
        {
            return _pairs.FirstOrDefault(value => value.@enum.Equals(@enum));
        }

        public IEnumerator GetEnumerator()
        {
            return _pairs.GetEnumerator();
        }
        
        [Serializable]
        private sealed class EnumValuePair
        {
            [SerializeField] [HideInInspector] private string name;

            public readonly TEnum @enum;
            public TValue value;

            public EnumValuePair(TEnum @enum)
            {
                this.@enum = @enum;
                name = @enum.ToString();
            }
        }
    }
}

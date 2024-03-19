using System;
using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Hotkeys;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    [Serializable]
    public class SerializableHotkeyInfo<TKey>
    {
        [SerializeField] private List<TKey> keys;

        public static implicit operator HotkeyInfo<TKey>(SerializableHotkeyInfo<TKey> self)
        {
            var result = new HotkeyInfo<TKey>(self.keys);
            return result;
        }
    }
}
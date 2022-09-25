using System;
using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Hotkeys.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Hotkeys
{
    [Serializable]
    public class SerializableHotkeyInfo : IHotkeyInfo
    {
        [SerializeField] private List<KeyCode> keys;
        [SerializeField] private bool sequence;
        [SerializeField] private bool allowHold;
        [SerializeField] private bool allowExcess;

        public IEnumerable<KeyCode> Keys => keys;
        public bool Sequence => sequence;
        public bool AllowHold => allowHold;
        public bool AllowExcess => allowExcess;
    }
}
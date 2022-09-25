using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Hotkeys.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Hotkeys
{
    public readonly struct HotkeyInfo : IHotkeyInfo
    {
        public HotkeyInfo(IEnumerable<KeyCode> keys, bool sequence, bool allowHold, bool allowExcess)
        {
            Keys = keys;
            Sequence = sequence;
            AllowHold = allowHold;
            AllowExcess = allowExcess;
        }

        public IEnumerable<KeyCode> Keys
        {
            get;
        }

        public bool Sequence
        {
            get;
        }

        public bool AllowHold
        {
            get;
        }

        public bool AllowExcess
        {
            get;
        }
    }
}

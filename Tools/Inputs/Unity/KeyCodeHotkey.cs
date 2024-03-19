using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Inputs.Hotkeys;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public class KeyCodeHotkey 
        : HotkeyInfo<KeyCode>
    {
        public KeyCodeHotkey(IEnumerable<KeyCode> keys) 
            : base(keys)
        {
            
        }

        public static explicit operator KeyCodeHotkey(KeyCode self)
        {
            var result = new KeyCodeHotkey(self.AsSingleEnumerable());
            return result;
        }
        
        public static KeyCodeHotkey operator +(KeyCodeHotkey left, KeyCode right)
        {
            var result = new KeyCodeHotkey(left.Keys.ConcatWith(right));
            return result;
        }
    }
}
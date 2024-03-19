using System;
using Birdhouse.Tools.Inputs.Hotkeys.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Unity
{
    public static class KeyCodeHotkeyHelper
    {
        public static Lazy<IHotkeyInfo<KeyCode>> Undo =
            new Lazy<IHotkeyInfo<KeyCode>>(() => (KeyCodeHotkey) KeyCode.LeftControl + KeyCode.Z);
        
        public static Lazy<IHotkeyInfo<KeyCode>> Redo =
            new Lazy<IHotkeyInfo<KeyCode>>(() => (KeyCodeHotkey) KeyCode.LeftControl + KeyCode.Y);
    }
}
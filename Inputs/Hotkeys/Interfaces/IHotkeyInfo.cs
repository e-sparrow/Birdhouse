using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Inputs.Hotkeys.Interfaces
{
    public interface IHotkeyInfo
    {
        IEnumerable<KeyCode> Keys
        {
            get;
        }

        bool Sequence
        {
            get;
        }

        bool AllowHold
        {
            get;
        }

        bool AllowExcess
        {
            get;
        }
    }
}
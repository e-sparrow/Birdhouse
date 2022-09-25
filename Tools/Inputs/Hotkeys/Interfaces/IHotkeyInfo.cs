using System.Collections.Generic;
using UnityEngine;

namespace Birdhouse.Tools.Inputs.Hotkeys.Interfaces
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
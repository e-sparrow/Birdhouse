using System.Collections.Generic;
using Birdhouse.Tools.Inputs.Hotkeys.Interfaces;

namespace Birdhouse.Tools.Inputs.Hotkeys
{
    public class HotkeyInfo<TKey>
        : IHotkeyInfo<TKey>
    {
        public HotkeyInfo(IEnumerable<TKey> keys)
        {
            Keys = keys;
        }

        public IEnumerable<TKey> Keys
        {
            get;
        }
    }
}

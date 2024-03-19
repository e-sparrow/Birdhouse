using System.Collections.Generic;

namespace Birdhouse.Tools.Inputs.Hotkeys.Interfaces
{
    public interface IHotkeyInfo<out TKey>
    {
        IEnumerable<TKey> Keys
        {
            get;
        }
    }
}
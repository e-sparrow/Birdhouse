using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Customization.Presets.Interfaces
{
    public interface IPresetManager<TKey>
    {
        void AddPreset(PresetAsset<TKey> preset);
        IEnumerable<PresetAsset<TKey>> LoadPresets();
    }
}
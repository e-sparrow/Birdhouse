using System.Collections.Generic;

namespace Birdhouse.Customization.Presets.Interfaces
{
    public interface IPresetManager<TKey>
    {
        void AddPreset(PresetAsset<TKey> preset);
        IEnumerable<PresetAsset<TKey>> LoadPresets();
    }
}
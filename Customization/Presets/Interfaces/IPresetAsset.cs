using System.Collections.Generic;

namespace Birdhouse.Customization.Presets.Interfaces
{
    public interface IPresetAsset
    {
        IEnumerable<IPreset> GetPresets();

        string Name
        {
            get;
        }
    }
}
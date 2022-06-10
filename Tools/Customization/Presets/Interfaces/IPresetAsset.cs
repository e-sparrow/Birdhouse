using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Customization.Presets.Interfaces
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
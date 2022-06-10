using System;
using System.Collections.Generic;
using ESparrow.Utils.Tools.Customization.Presets.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Customization.Presets
{
    public class PresetAsset<TKey> : ScriptableObject, IPresetAsset
    {
        public IEnumerable<IPreset> GetPresets()
        {
            throw new NotImplementedException(); 
        }

        public string Name => name;
    }
}
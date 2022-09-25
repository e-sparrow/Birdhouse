using System;
using System.Collections.Generic;
using Birdhouse.Customization.Presets.Interfaces;
using UnityEngine;

namespace Birdhouse.Customization.Presets
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
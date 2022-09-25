using System.Collections.Generic;
using System.Text.RegularExpressions;
using Birdhouse.Common.Helpers;
using Birdhouse.Customization.Presets.Interfaces;
using Birdhouse.Tools.Serialization.Enums;
using Birdhouse.Tools.Serialization.Interfaces;
using UnityEngine;

namespace Birdhouse.Customization.Presets
{
    public class PresetManager<TKey> : IPresetManager<TKey>
    {
        private const ESerializationMethod Method = ESerializationMethod.Binary;
        
        private const string RegexPattern = "*s_preset";

        private readonly static Regex Regex = new Regex(RegexPattern);
        
        private readonly ISerializationController Controller = 
            SerializationHelper.GetDefaultSerializationController(Method, Application.streamingAssetsPath);
        
        public void AddPreset(PresetAsset<TKey> preset)
        {
            Controller.Serialize(preset);
        }

        public IEnumerable<PresetAsset<TKey>> LoadPresets()
        {
            return null;
        }
    }
}
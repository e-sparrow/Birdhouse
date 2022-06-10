using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Serialization.Enums;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Customization.Presets.Interfaces;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace ESparrow.Utils.Tools.Customization.Presets
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
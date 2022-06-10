using System;
using UnityEditor;
using UnityEngine;

namespace ESparrow.Utils.Tools.Customization.Presets
{
    public class PresetWindow : EditorWindow
    {
        public static void Open(SerializedProperty property)
        {
            var window = GetWindow<PresetWindow>();
            window.titleContent = new GUIContent($"{property.name} preset");
        }
        
        private void CreateGUI()
        {
            
        }
    }
}
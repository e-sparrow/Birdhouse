using UnityEditor;
using UnityEngine;

namespace Birdhouse.Customization.Presets
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
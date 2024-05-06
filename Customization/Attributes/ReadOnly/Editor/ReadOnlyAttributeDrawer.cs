#if UNITY_EDITOR
using Birdhouse.Customization.Attributes.ConditionalHide.Editor;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Customization.Attributes.ReadOnly.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var temp = GUI.enabled;
            
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);
            GUI.enabled = temp;
        }
    }
}
#endif
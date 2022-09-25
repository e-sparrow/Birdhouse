using Birdhouse.Customization.Attributes.ReadOnly;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tools.Customization.Attributes.ConditionalHide
{
    #if UNITY_EDITOR
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
    #endif
}
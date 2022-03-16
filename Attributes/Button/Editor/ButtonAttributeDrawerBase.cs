using ESparrow.Utils.Extensions;
using UnityEditor;
using UnityEngine;

namespace ESparrow.Utils.Attributes.Button.Editor
{
    [CustomPropertyDrawer(typeof(ButtonAttributeBase))]
    public class ButtonAttributeDrawerBase : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var target = (ButtonAttributeBase) attribute;
            var instance = property.GetParentType();
            base.OnGUI(position, property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}
using ESparrow.Utils.Extensions;
using UnityEditor;
using UnityEngine;

namespace ESparrow.Utils.Experimental.Editor
{
    [CustomPropertyDrawer(typeof(TestModuleBase))]
    public class TestModuleDrawerBase : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var target = property.serializedObject.targetObject;

            EditorGUI.BeginProperty(position, label, property);
            
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var buttonRect = new Rect(position.x, position.y + 30, position.width, position.height);

            var requiredTest = GUI.Button(buttonRect, "Test");
            if (requiredTest)
            {
                fieldInfo.GetType().GetMethod("Test").Invoke(target, null);
            }
            
            EditorGUI.EndProperty();
        }
    }
}

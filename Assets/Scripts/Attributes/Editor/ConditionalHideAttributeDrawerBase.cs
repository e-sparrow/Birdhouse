using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utils.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(ConditionalHideAttributeBase))]
    public abstract class ConditionalHideAttributeDrawerBase : PropertyDrawer
    {
        private const BindingFlags DefaultBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var target = (ConditionalHideAttributeBase) attribute;
            
            bool temp = GUI.enabled;
            bool enabled = GetConditionalHideAttributeResult(target, property);
            
            GUI.enabled = enabled;
            if (!target.HideInInspector || enabled)
            {
                EditorGUI.PropertyField(position, property, label, true);
            }

            GUI.enabled = temp;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var target = (ConditionalHideAttributeBase) attribute;
            bool enabled = GetConditionalHideAttributeResult(target, property);

            if (!target.HideInInspector || enabled)
            {
                return EditorGUI.GetPropertyHeight(property, label);
            }
                
            return -EditorGUIUtility.standardVerticalSpacing;
        }

        private bool GetConditionalHideAttributeResult(ConditionalHideAttributeBase targetAttribute, SerializedProperty property)
        {
            bool enabled = true;
            
            string propertyPath = property.propertyPath;
            string conditionPath = propertyPath.Replace(property.name,targetAttribute.ConditionalSourceField);

            var target = property.serializedObject.FindProperty(conditionPath);
            if (target != null)
            {
                enabled = targetAttribute.IsFit(target);
            }
            else
            {
                var warning = "Attempting to use a ConditionalHideAttribute but no matching SourcePropertyValue found in object: ";
                Debug.LogWarning(warning + targetAttribute.ConditionalSourceField);
            }

            return enabled;
        }
    }
}
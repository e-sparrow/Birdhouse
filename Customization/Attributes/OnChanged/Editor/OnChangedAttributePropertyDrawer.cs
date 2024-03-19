using System;
using Birdhouse.Common.Extensions;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Customization.Attributes.OnChanged.Editor
{
    [CustomPropertyDrawer(typeof(OnChangedAttribute))]
    public class OnChangedAttributePropertyDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);

            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }
            
            var onChangedAttribute = attribute as OnChangedAttribute;
            
            var type = property
                .serializedObject
                .targetObject
                .GetType();
            
            var methods = type.GetMethods();

            var hasMethod = methods.TryGetFirst(value => value.Name == onChangedAttribute.MethodName, out var method);
            if (hasMethod)
            {
                var isCorrect = method != null && method.GetParameters().Length == 0;
                if (isCorrect)
                {
                    method.Invoke(property.serializedObject.targetObject, null);
                }
                else
                {
                    var methodIsNotCorrectMessage = $"The method with name {method.Name} shouldn't contain any parameters!";
                    throw new ArgumentException(methodIsNotCorrectMessage);
                }
            }
            else
            {
                var noSuchMethodMessage = $"The class \"{type.Name}\" doesn't contain method with name {onChangedAttribute.MethodName}!";
                throw new ArgumentException(noSuchMethodMessage);
            }
        }
    }
}
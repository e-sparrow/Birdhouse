using System;
using System.Linq;
using System.Reflection;
using Birdhouse.Tools.Customization.TypeSerialization.Abstractions;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tools.Customization.TypeSerialization
{
    [Serializable]
    public struct AssignablesSelector<T>
    {
        [SerializeField] private string assemblyName;
        [SerializeField] private string typeName;

        public string AssemblyName => assemblyName;
        public string TypeName => typeName;

#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(AssignablesSelector<>), true)]
        public abstract class AssignablesSelectorDrawer
            : PropertyDrawer
        {
            private static IReadOnlyTypePreloader typePreloader;
            
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                typePreloader ??= PreloadedTypesHelper.GetAssignablesPreloader(typeof(T));
                
                var types = typePreloader.GetTypes().ToArray();
                var typeNames = types.Select(value => value.Name).ToArray();

                var fullNames = types
                    .Select(value => $"{value.Assembly.FullName.Split(',').First()}/{value.Name}")
                    .ToArray();

                var assemblyNameProperty = property.FindPropertyRelative(nameof(assemblyName));
                var typeNameProperty = property.FindPropertyRelative(nameof(typeName));

                var index = 0;

                if (assemblyNameProperty.stringValue.Length > 0)
                {
                    var assembly = Assembly.Load(assemblyNameProperty.stringValue);
                    if (assembly != null)
                    {
                        var type = assembly
                            .DefinedTypes
                            .FirstOrDefault(value => value.Name == typeNameProperty.stringValue.Split('/').Last());

                        if (type != default)
                        {
                            index = Array.IndexOf(typeNames, type.Name);
                        }
                    }
                }

                index = EditorGUI.Popup(position, label.text, index, fullNames);

                typeNameProperty.stringValue = fullNames[index];
                assemblyNameProperty.stringValue = types[index].Assembly.FullName;
            }
        }
#endif
    }
}
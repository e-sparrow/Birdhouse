using System;
using System.Reflection;
using UnityEditor;

namespace Birdhouse.Common.Extensions
{
    #if UNITY_EDITOR
    public static class EditorExtensions
    {
        public static Type GetParentType(this SerializedProperty self)
        {
            var type = self.serializedObject.targetObject.GetType();
            return type;
        }
        
        public static FieldInfo GetFieldInfo(this SerializedProperty self)
        {
            var parentType = self.GetParentType();
            var fieldInfo = parentType.GetFieldViaPath(self.propertyPath);
            
            return fieldInfo;
        }
        
        public static object GetValue(this SerializedProperty self)
        {
            object targetObject = self.serializedObject.targetObject;
        
            var field = targetObject.GetType().GetField(self.propertyPath.Split('.')[0]);
            if (field == null) return default;
        
            object fieldValue = field.GetValue(targetObject);
        
            string[] path = self.propertyPath.Split('.');
            for (int i = 1; i < path.Length; i++)
            {
                fieldValue = fieldValue.GetType().GetField(path[i]).GetValue(fieldValue);
                if (fieldValue == null) break;
            }
        
            return fieldValue;
        }

        public static T GetValue<T>(this SerializedProperty self)
        {
            return (T) self.GetValue();
        }
        
        public static void SetValue(this SerializedProperty self, object value)
        {
            var fieldInfo = self.GetFieldInfo();
            fieldInfo.SetValue(self.serializedObject.targetObject, value);
        }
        
        public static FieldInfo GetFieldViaPath(this Type type, string path, BindingFlags? flags = null)
        {
            const BindingFlags DefaultFlags = BindingFlags.Default | BindingFlags.GetField |
                                              BindingFlags.SetField | BindingFlags.Public |
                                              BindingFlags.Public | BindingFlags.NonPublic | 
                                              BindingFlags.Instance;

            flags ??= DefaultFlags;
            
            var fieldInfo = type.GetField(path);
            var names = path.Split('.');

            var currentType = type;
            foreach (var name in names)
            {
                fieldInfo = currentType.GetField(name, flags.Value);

                if (fieldInfo != null)
                {
                    currentType = fieldInfo.FieldType;
                }
                else
                {
                    return null;
                }
            }

            return fieldInfo;
        }
    }
    #endif
}
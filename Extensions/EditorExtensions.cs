using System;
using System.Reflection;
using UnityEditor;

namespace ESparrow.Utils.Extensions
{
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
            var fieldInfo = parentType.GetField(self.propertyPath);
            
            return fieldInfo;
        }
        
        public static object GetValue(this SerializedProperty self)
        {
            var fieldInfo = self.GetFieldInfo();
            var value = fieldInfo.GetValue(self.serializedObject.targetObject);

            return value;
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
        
        public static FieldInfo GetFieldViaPath(this Type type, string path)
        {
            var fieldInfo = type.GetField(path);
            var names = path.Split('.');

            var currentType = type;
            foreach (string name in names)
            {
                fieldInfo = currentType.GetField(name);

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
}
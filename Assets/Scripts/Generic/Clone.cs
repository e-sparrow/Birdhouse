using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Generic
{
    public static class Clone<T>
    {
        public static T[] CreateClones(T original, int count)
        {
            var list = new List<T>();
            for (int i = 0; i < count; i++)
            {
                list.Add(CreateClone(original));
            }

            return list.ToArray();
        }

        public static T CreateClone(T original)
        {
            var properties = typeof(T).GetProperties(ReflectionHelper.AnyBindingFlags);

            var clone = Activator.CreateInstance<T>();

            foreach (var property in properties)
            {
                if (property.PropertyType.Namespace == original.GetType().Namespace)
                {
                    var value = property.GetValue(original);
                    property.SetValue(clone, Clone<object>.CreateClone(value));
                }
                else
                {
                    property.SetValue(clone, property.GetValue(original));
                }
            }

            return (T) clone;
        } 
    }
}

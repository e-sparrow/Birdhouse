using System;
using System.Linq;
using System.Reflection;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Generic
{
    public static class Clone<T>
    {
        public static T[] GetClones(T original, int count)
        {
            return Enumerable.Repeat(GetClone(original), count).ToArray();
        }

        public static T GetClone(T original)
        {
            var properties = typeof(T).GetProperties(ReflectionHelper.AnyBindingFlags);
            var constructors = typeof(T).GetConstructors(ReflectionHelper.AnyBindingFlags);
            var clone = constructors[0].Invoke(null);

            foreach (var property in properties)
            {
                if (property.PropertyType.Namespace == original.GetType().Namespace)
                {
                    var value = property.GetValue(original);
                    property.SetValue(clone, Clone<object>.GetClone(value));
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

using System;
using System.Collections.Generic;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Generic.Vectors
{
    public static class CloneHelper<T>
    {   
        public static IEnumerable<T> CreateClones(T original, int count)
        {
            return EnumerablesHelper.RepeatWithResult(() => CreateClone(original), count);
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
                    property.SetValue(clone, CloneHelper<object>.CreateClone(value));
                }
                else
                {
                    property.SetValue(clone, property.GetValue(original));
                }
            }

            return clone;
        }
    }
}

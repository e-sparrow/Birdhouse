using System;
using System.Linq;
using System.Reflection;

namespace ESparrow.Utils.Extensions
{
    public static class ReflectionExtensions
    {
        public static string[] GetMutableMemberNames(this Type type, BindingFlags flags)
        {
            var fields = type.GetFields(flags);
            var properties = type.GetProperties(flags);

            var memberNames = properties.Select(property => property.Name).Concat(fields.Select(field => field.Name)).ToArray();

            return memberNames;
        }

        public static Type[] GetSubclasses(this Type self, bool nesting = false)
        {
            var assembly = self.Assembly;
            var types = assembly.GetTypes().Where(Func).ToArray();

            return types;

            bool Func(Type type)
            {
                if (nesting)
                {
                    return type.IsSubclassOf(self);
                }
                else
                {
                    return type.BaseType.Equals(self);
                }
            }
        }

        public static Type[] GetSubclasses(this Type self, int nestingLevel)
        {
            var subclasses = self.GetSubclasses();
            if (nestingLevel <= 1 || subclasses.Length == 0)
            {
                return subclasses;
            }
            else
            {
                var subsubclasses = subclasses.SelectMany(value => value.GetSubclasses(nestingLevel - 1));
                return subclasses.Concat(subsubclasses).ToArray();
            }
        }

        private static bool IsMutableProperty(this PropertyInfo property)
        {
            return property.CanRead && property.CanWrite;
        }
    }
}

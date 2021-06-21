using System;
using System.Linq;
using System.Reflection;

namespace ESparrow.Utils.Extensions
{   
    public static class ReflectionExtensions
    {
        public static Type[] GetSubclasses(this Type baseType, bool nesting = false)
        {
            var assembly = baseType.Assembly;
            var types = assembly.GetTypes().Where(Func).ToArray();

            return types;

            bool Func(Type type)
            {
                if (nesting)
                {
                    return type.IsSubclassOf(baseType);
                }
                else
                {
                    return type.BaseType.Equals(baseType);
                }
            }
        }

        public static Type[] GetSubclasses(this Type type, int nestingLevel)
        {
            var subclasses = type.GetSubclasses();
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

        public static bool IsMutable(this MemberInfo member)
        {
            return member.MemberType == (MemberTypes.Field | MemberTypes.Property);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ESparrow.Utils.Extensions
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets names of all the mutable members of specified type.
        /// </summary>
        /// <param name="self">Self type</param>
        /// <param name="flags">BindingFlags for mutable members</param>
        /// <returns>Enumerable with names of members</returns>
        public static IEnumerable<string> GetMutableMemberNames(this Type self, BindingFlags flags)
        {
            var fields = self.GetFields(flags);
            var properties = self.GetProperties(flags);

            var memberNames = properties.Select(property => property.Name).Concat(fields.Select(field => field.Name)).ToArray();

            return memberNames;
        }

        /// <summary>
        /// Gets subclasses of self type.
        /// </summary>
        /// <param name="self">Self type</param>
        /// <param name="nesting">Get nested subclasses or not</param>
        /// <returns>Subclasses of self type</returns>
        public static IEnumerable<Type> GetSubclasses(this Type self, bool nesting = false)
        {
            var assembly = self.Assembly;
            var types = assembly.GetTypes().Where(IsSubclass).ToArray();

            return types;

            bool IsSubclass(Type type)
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

        /// <summary>
        /// Gets subclasses with specified nesting level.
        /// </summary>
        /// <param name="self">Self type</param>
        /// <param name="nestingLevel">Nesting level</param>
        /// <returns>Subclasses of self type</returns>
        public static IEnumerable<Type> GetSubclasses(this Type self, int nestingLevel)
        {
            var subclasses = self.GetSubclasses();
            if (nestingLevel <= 1 || subclasses.Count() == 0)
            {
                return subclasses;
            }
            else
            {
                var subsubclasses = subclasses.SelectMany(value => value.GetSubclasses(nestingLevel - 1));
                return subclasses.Concat(subsubclasses).ToArray();
            }
        }
        
        /// <summary>
        /// Checks is self class is real.
        /// </summary>
        /// <param name="self">Self class</param>
        /// <returns>True if it's real class and false otherwise</returns>
        public static bool IsRealClass(this Type self)
        {
            return !self.IsAbstract && !self.IsGenericTypeDefinition && !self.IsInterface;
        }
        
        /// <summary>
        /// Checks for mutation opportunity for this property.
        /// </summary>
        /// <param name="self">Self property</param>
        /// <returns>True if self property is mutable and false otherwise</returns>
        private static bool IsMutableProperty(this PropertyInfo self)
        {
            return self.CanRead && self.CanWrite;
        }
    }
}

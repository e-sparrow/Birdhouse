using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Reflection.MutableMembers;
using ESparrow.Utils.Reflection.MutableMembers.Adapters;
using ESparrow.Utils.Reflection.MutableMembers.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets all the mutable members of self type.
        /// </summary>
        /// <param name="self">Self type</param>
        /// <returns>All the mutable members of self type</returns>
        public static IEnumerable<IMutable> GetMutableMembers(this Type self)
        {
            var list = new List<IMutable>();
            
            var fields = self.GetFields().Where(MutableValidator.IsValidField);
            foreach (var field in fields)
            {
                var mutableField = new FieldToMutableAdapter(field);
                list.Add(mutableField);
            }
            
            var properties = self.GetProperties().Where(MutableValidator.IsValidProperty);
            foreach (var property in properties)
            {
                var mutableProperty = new PropertyToMutableAdapter(property);
                list.Add(mutableProperty);
            }

            return list;
        }

        /// <summary>
        /// Gets the specified mutable member of self type.
        /// </summary>
        /// <param name="self">Self type</param>
        /// <param name="name">Name of specified mutable member</param>
        /// <param name="mutable">Mutable variable by name</param>
        /// <returns>Specified mutable member</returns>
        public static bool TryGetMutableMember(this Type self, string name, out IMutable mutable)
        {
            mutable = default;
            if (IsField())
            {
                var field = self.GetField(name);
                mutable = new FieldToMutableAdapter(field);
            }
            else if (IsProperty())
            {
                var property = self.GetProperty(name);
                mutable = new PropertyToMutableAdapter(property);
            }

            return false;
            
            bool IsField()
            {
                return MutableValidator.IsValidField(self.GetField(name));
            }

            bool IsProperty()
            {
                return MutableValidator.IsValidProperty(self.GetProperty(name));
            }
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
            if (nestingLevel <= 1 || !subclasses.Any())
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
    }
}

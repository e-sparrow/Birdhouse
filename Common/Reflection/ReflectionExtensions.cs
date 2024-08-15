using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Reflection.MutableMembers;
using Birdhouse.Common.Reflection.MutableMembers.Adapters;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool TryGetEmptyConstructor(this Type self, out ConstructorInfo result)
        {
            result = self
                .GetConstructors()
                .FirstOrDefault(value => !value.GetParameters().Any());

            var isNotNull = result != null;
            return isNotNull;
        }
        
        public static bool HasEmptyConstructors(this Type self)
        {
            var result = self
                .GetConstructors()
                .Any(value => !value.GetParameters().Any());

            return result;
        }
        
        public static bool HasCustomAttribute<T>(this Type self) 
            where T : Attribute
        {
            var result = self.GetCustomAttribute<T>() != null;
            return result;
        }
        
        public static bool HasCustomAttribute<T>(this MemberInfo self) 
            where T : Attribute
        {
            var result = self.GetCustomAttribute<T>() != null;
            return result;
        }

        public static bool TryGetCustomAttribute<T>(this MemberInfo self, out T result)
            where T : Attribute
        {
            result = self.GetCustomAttribute<T>();
            
            var isExist = result != null;
            return isExist;
        }
        
        public static bool IsStatic(this Type type)
        {
            // This is really strange thing but static types are declared as abstract and sealed at the same time at IL level
            var result = type.IsAbstract && type.IsSealed;
            return result;
        }

        public static IEnumerable<MethodInfo> GetEmptyMethods(this Type self)
        {
            var result = self
                .GetMethods()
                .Where(value => value.GetParameters().Length == 0 && value.ReturnType == typeof(void));

            return result;
        }

        public static IEnumerable<IWritable> GetWritableMembers(this Type self)
        {
            var list = new List<IWritable>();

            var fields = self.GetFields().Where(MutableValidator.IsWritable);
            foreach (var field in fields)
            {
                var writableField = new FieldToWritableAdapter(field);
                list.Add(writableField);
            }
            
            var properties = self.GetProperties().Where(MutableValidator.IsWritable);
            foreach (var property in properties)
            {
                var writableProperty = new PropertyToWritableAdapter(property);
                list.Add(writableProperty);
            }

            var methods = self.GetMethods().Where(MutableValidator.IsWritable);
            foreach (var method in methods)
            {
                var writableMethod = new MethodToWritableAdapter(method);
                list.Add(writableMethod);
            }

            return list;
        }

        public static IEnumerable<IReadable> GetReadableMembers(this Type self)
        {
            var list = new List<IReadable>();
            
            var fields = self.GetFields();
            foreach (var field in fields)
            {
                var readableField = new FieldToReadableAdapter(field);
                list.Add(readableField);
            }
            
            var properties = self.GetProperties().Where(MutableValidator.IsReadable);
            foreach (var property in properties)
            {
                var readableProperty = new PropertyToReadableAdapter(property);
                list.Add(readableProperty);
            }

            var methods = self.GetMethods().Where(MutableValidator.IsReadable);
            foreach (var method in methods)
            {
                var readableMethod = new MethodToReadableAdapter(method);
                list.Add(readableMethod);
            }

            return list;
        }
        
        /// <summary>
        /// Gets all the mutable members of self type.
        /// </summary>
        /// <param name="self">Self type</param>
        /// <returns>All the mutable members of self type</returns>
        public static IEnumerable<IMutable> GetMutableMembers(this Type self)
        {
            var list = new List<IMutable>();
            
            var fields = self.GetFields().Where(MutableValidator.IsMutable);
            foreach (var field in fields)
            {
                var mutableField = new FieldToMutableAdapter(field);
                list.Add(mutableField);
            }
            
            var properties = self.GetProperties().Where(MutableValidator.IsMutable);
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
            
            switch (self.MemberType)
            {
                case MemberTypes.Field:
                    var field = self.GetField(name);
                    var isMutableField = field.TryCreateMutable(out mutable);
                    return isMutableField;
                
                case MemberTypes.Property:
                    var property = self.GetProperty(name);
                    var isMutableProperty = property.TryCreateMutable(out mutable);
                    return isMutableProperty;
                
                default:
                    return false;
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

        public static bool TryGetCustomAttribute<T>(this Type type, out T result) where T : Attribute
        {
            result = type.GetCustomAttribute<T>();

            var isNotNull = result != null;
            return isNotNull;
        }

        public static bool TryGetCustomAttribute<T>(this ParameterInfo parameter, out T result) where T : Attribute
        {
            result = parameter.GetCustomAttribute<T>();

            var isNotNull = result != null;
            return isNotNull;
        }
    }
}

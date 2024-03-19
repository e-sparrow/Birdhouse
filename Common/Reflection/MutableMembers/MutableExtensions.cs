using System;
using System.Linq;
using System.Reflection;
using Birdhouse.Common.Reflection.MutableMembers.Adapters;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Common.Reflection.MutableMembers
{
    public static class MutableExtensions
    {
        public static bool TryCreateWritable(this MemberInfo self, out IWritable result, out Type type)
        {
            result = default;
            type = null;
            
            switch (self.MemberType)
            {
                case MemberTypes.Field:
                    var field = self.DeclaringType.GetField(self.Name);
                    var isWritableField = MutableValidator.IsWritable(field);
                    result = new FieldToWritableAdapter(field);
                    type = field.FieldType;
                    return isWritableField;
                
                case MemberTypes.Property:
                    var property = self.DeclaringType.GetProperty(self.Name);
                    var isWritableProperty = MutableValidator.IsWritable(property);
                    result = new PropertyToWritableAdapter(property);
                    type = property.PropertyType;
                    return isWritableProperty;
                
                case MemberTypes.Method:
                    var method = self.DeclaringType.GetMethod(self.Name);
                    var isWritableMethod = MutableValidator.IsWritable(method);
                    result = new MethodToWritableAdapter(method);
                    type = method.GetParameters().First().ParameterType;
                    return isWritableMethod;
                
                default:
                    return false;
            }
        }
        
        public static bool TryCreateWritable(this FieldInfo self, out IWritable result)
        {
            result = default;

            var isWritable = MutableValidator.IsWritable(self);
            if (isWritable)
            {
                result = new FieldToWritableAdapter(self);
            }

            return isWritable;
        }

        public static bool TryCreateWritable(this PropertyInfo self, out IWritable result)
        {
            result = default;

            var isWritable = MutableValidator.IsWritable(self);
            if (isWritable)
            {
                result = new PropertyToWritableAdapter(self);
            }

            return isWritable;
        }
        
        public static bool TryCreateReadable(this MemberInfo self, out IReadable result, out Type type)
        {
            result = default;
            type = null;
            
            switch (self.MemberType)
            {
                case MemberTypes.Field:
                    var field = self.DeclaringType.GetField(self.Name);
                    var isReadableField = MutableValidator.IsWritable(field);
                    result = new FieldToReadableAdapter(field);
                    type = field.FieldType;
                    return isReadableField;
                
                case MemberTypes.Property:
                    var property = self.DeclaringType.GetProperty(self.Name);
                    var isReadableProperty = MutableValidator.IsWritable(property);
                    result = new PropertyToReadableAdapter(property);
                    type = property.PropertyType;
                    return isReadableProperty;
                
                case MemberTypes.Method:
                    var method = self.DeclaringType.GetMethod(self.Name);
                    var isReadableMethod = MutableValidator.IsWritable(method);
                    result = new MethodToReadableAdapter(method);
                    type = method.ReturnType;
                    return isReadableMethod;
                
                default:
                    return false;
            }
        }
        
        public static bool TryCreateReadable(this FieldInfo self, out IReadable result)
        {
            result = new FieldToReadableAdapter(self);
            return true;
        }

        public static bool TryCreateReadable(this PropertyInfo self, out IReadable result)
        {
            result = default;

            var isReadable = MutableValidator.IsReadable(self);
            if (isReadable)
            {
                result = new PropertyToReadableAdapter(self);
            }

            return isReadable;
        }

        public static bool TryCreateReadable(this MethodInfo self, out IReadable result)
        {
            result = default;

            var isReadable = MutableValidator.IsReadable(self);
            if (isReadable)
            {
                result = new MethodToReadableAdapter(self);
            }

            return isReadable;
        }
        
        public static bool TryCreateMutable(this FieldInfo self, out IMutable result)
        {
            result = default;

            var isWritable = TryCreateWritable(self, out var writable);
            if (isWritable)
            {
                var readable = new FieldToReadableAdapter(self);
                result = new Mutable(writable, readable);
                
                return true;
            }

            return false;
        }

        public static bool TryCreateMutable(this PropertyInfo self, out IMutable result)
        {
            result = default;

            var isWritable = TryCreateWritable(self, out var writable);
            if (!isWritable)
            {
                return false;
            }

            var isReadable = TryCreateReadable(self, out var readable);
            if (!isReadable)
            {
                return false;
            }

            result = new Mutable(writable, readable);
            return true;
        }
    }
}
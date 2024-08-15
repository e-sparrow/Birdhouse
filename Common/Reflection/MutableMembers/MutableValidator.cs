using System.Reflection;

namespace Birdhouse.Common.Reflection.MutableMembers
{
    public static class MutableValidator
    {
        public static bool IsWritable(MemberInfo memberInfo)
        {
            if (memberInfo.MemberType == MemberTypes.Field)
            {
                return IsWritable(memberInfo as FieldInfo);
            }

            if (memberInfo.MemberType == MemberTypes.Property)
            {
                return IsWritable(memberInfo as PropertyInfo);
            }

            if (memberInfo.MemberType == MemberTypes.Method)
            {
                return IsWritable(memberInfo as MethodInfo);
            }

            return false;
        }
        
        public static bool IsReadable(MemberInfo memberInfo)
        {
            if (memberInfo.MemberType == MemberTypes.Field)
            {
                return true;
            }

            if (memberInfo.MemberType == MemberTypes.Property)
            {
                return IsReadable(memberInfo as PropertyInfo);
            }

            if (memberInfo.MemberType == MemberTypes.Method)
            {
                return IsReadable(memberInfo as MethodInfo);
            }

            return false;
        }
        
        public static bool IsWritable(FieldInfo fieldInfo)
        {
            var result = !fieldInfo.IsInitOnly;
            return result;
        }
        
        public static bool IsWritable(PropertyInfo propertyInfo)
        {
            var result = propertyInfo.CanWrite;
            return result;
        }

        public static bool IsWritable(MethodInfo methodInfo)
        {
            var result = methodInfo.GetParameters().Length == 1;
            return result;
        }
        
        public static bool IsReadable(PropertyInfo propertyInfo)
        {
            var result = propertyInfo.CanRead;
            return result;
        }

        public static bool IsReadable(MethodInfo methodInfo)
        {
            var result = methodInfo.ReturnType != typeof(void) && methodInfo.GetParameters().Length == 0;
            return result;
        }
        
        public static bool IsMutable(FieldInfo fieldInfo)
        {
            var result = IsWritable(fieldInfo);
            return result;
        }

        public static bool IsMutable(PropertyInfo propertyInfo)
        {
            var result = IsWritable(propertyInfo) && IsReadable(propertyInfo);
            return result;
        }
    }
}
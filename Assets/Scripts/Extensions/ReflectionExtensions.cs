using System.Reflection;

namespace ESparrow.Utils.Extensions
{   
    public static class ReflectionExtensions
    {
        public static bool IsMutable(this MemberInfo member)
        {
            return member.MemberType == (MemberTypes.Field | MemberTypes.Property);
        }
    }
}

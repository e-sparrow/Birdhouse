using System.Reflection;

namespace ESparrow.Utils.Reflection.MutableMembers
{
    public static class MutableValidator
    {
        /// <summary>
        /// Checks is specified field info valid.
        /// </summary>
        /// <param name="fieldInfo">Specified field info</param>
        /// <returns>True if it's valid and false otherwise</returns>
        public static bool IsValidField(FieldInfo fieldInfo)
        {
            return !fieldInfo.IsInitOnly;
        }

        /// <summary>
        /// Checks is specified property info valid.
        /// </summary>
        /// <param name="propertyInfo">Specified property info</param>
        /// <returns>True if it's valid and false otherwise</returns>
        public static bool IsValidProperty(PropertyInfo propertyInfo)
        {
            return propertyInfo.CanRead && propertyInfo.CanWrite;
        }
    }
}
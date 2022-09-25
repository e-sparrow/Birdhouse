namespace Birdhouse.Common.Extensions
{
    public static class EqualityExtensions
    {
        /// <summary>
        /// Checks for nullity of self.
        /// </summary>
        /// <param name="self">Self value to check</param>
        /// <returns>True if self is null and false otherwise</returns>
        public static bool IsNull(this object self)
        {
            return ReferenceEquals(null, self);
        }

        /// <summary>
        /// Checks for not-nullity of self.
        /// </summary>
        /// <param name="self">Self value to check</param>
        /// <returns>False if self is null and true otherwise</returns>
        public static bool IsNotNull(this object self)
        {
            return !self.IsNull();
        }

        /// <summary>
        /// Checks for equality of references to two values.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another value</param>
        /// <returns>True if references are match and false otherwise</returns>
        public static bool IsReferencesMatchWith(this object self, object other)
        {
            return ReferenceEquals(self, other);
        }

        /// <summary>
        /// Checks for equality of types of two values.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another value</param>
        /// <returns>True if types are match and false otherwise</returns>
        public static bool IsTypesMatchWith(this object self, object other)
        {
            return other.GetType() == self.GetType();
        }
    }
}
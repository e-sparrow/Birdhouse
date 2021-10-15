namespace ESparrow.Utils.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Converts bool to int.
        /// </summary>
        /// <param name="self">Bool to convert</param>
        /// <returns>1 if self is true and 0 otherwise</returns>
        public static int Sign(this bool self)
        {
            return self ? 1 : 0;
        }

        /// <summary>
        /// Inverse the boolean.
        /// </summary>
        /// <param name="self">Boolean to inverse</param>
        /// <returns>True if self is false and false otherwise</returns>
        public static bool Inversed(this bool self)
        {
            return !self;
        }

        /// <summary>
        /// Does AND logic.
        /// </summary>
        /// <param name="self">Self boolean</param>
        /// <param name="other">Another boolean</param>
        /// <returns>True if self and other is true and false otherwise</returns>
        public static bool And(this bool self, bool other)
        {
            return self && other;
        }

        /// <summary>
        /// Does OR logic.
        /// </summary>
        /// <param name="self">Self boolean</param>
        /// <param name="other">Another boolean</param>
        /// <returns>True if self or other is true and false otherwise</returns>
        public static bool Or(this bool self, bool other)
        {
            return self || other;
        }

        /// <summary>
        /// Does XOR logic.
        /// </summary>
        /// <param name="self">Self boolean</param>
        /// <param name="other">Another boolean</param>
        /// <returns>True if one of booleans is true and other is false and false otherwise</returns>
        public static bool Xor(this bool self, bool other)
        {
            return self ^ other;
        }
    }
}

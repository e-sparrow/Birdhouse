namespace ESparrow.Utils.Extensions
{
    public static class BoolExtensions
    {
        public static int Sign(this bool self)
        {
            return self ? 1 : 0;
        }

        public static bool Inversed(this bool self)
        {
            return !self;
        }

        public static bool And(this bool self, bool other)
        {
            return self && other;
        }

        public static bool Or(this bool self, bool other)
        {
            return self || other;
        }

        public static bool Xor(this bool self, bool other)
        {
            return self ^ other;
        }
    }
}

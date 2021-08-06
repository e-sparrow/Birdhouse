using System;

namespace ESparrow.Utils.Extensions
{
    public static class ConvertExtensions
    {
        public static double ToDouble(this float self)
        {
            return Convert.ToDouble(self);
        }

        public static double ToDouble(this int self)
        {
            return Convert.ToDouble(self);
        }

        public static float ToFloat(this double self)
        {
            return (float) self;
        }

        public static float ToFloat(this int self)
        {
            return self;
        }
    }
}

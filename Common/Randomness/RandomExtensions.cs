using System;

namespace Birdhouse.Common.Randomness
{
    public static class RandomExtensions
    {
        public static double NextDouble(this Random self, double minValue, double maxValue) => minValue + self.NextDouble() * (maxValue - minValue);

        public static float NextFloat(this Random self) => (float) self.NextDouble();
        public static float NextFloat(this Random self, float minValue, float maxValue) => minValue + self.NextFloat() * (maxValue - minValue);
    }
}
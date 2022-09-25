using Birdhouse.Common.Extensions;

namespace Birdhouse.Common.Helpers
{
    public static class EasingHelper
    {
        public static class Easings
        {
            public static float Default(float progress)
            {
                return progress;
            }
        }

        public static class Operations
        {
            public static float Increase(float left, float right)
            {
                return left + right;
            }
            
            public static float Decrease(float left, float right)
            {
                return left - right;
            }
            
            public static float Multiple(float left, float right)
            {
                return left * right;
            }
            
            public static float Divide(float left, float right)
            {
                return left / right;
            }
            
            public static float Modulus(float left, float right)
            {
                return left % right;
            }

            public static float Power(float left, float right)
            {
                return left.Power(right);
            }
            
            public static float Average(float left, float right)
            {
                return (left + right) / 2;
            }
        }
    }
}

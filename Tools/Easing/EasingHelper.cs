using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Easing.Interfaces;

namespace Birdhouse.Tools.Easing
{
    public static class EasingHelper
    {
        public static class Operations
        {
            public static float Increase(float left, float right)
            {
                var result = left + right;
                return result;
            }
            
            public static float Decrease(float left, float right)
            {
                var result = left - right;
                return result;
            }
            
            public static float Multiple(float left, float right)
            {
                var result = left * right;
                return result;
            }
            
            public static float Divide(float left, float right)
            {
                var result = left / right;
                return result;
            }
            
            public static float Modulus(float left, float right)
            {
                var result = left % right;
                return result;
            }

            public static float Power(float left, float right)
            {
                var result = left.Power(right);
                return result;
            }
            
            public static float Average(float left, float right)
            {
                var result = (left + right) / 2;
                return result;
            }
        }
    }
}

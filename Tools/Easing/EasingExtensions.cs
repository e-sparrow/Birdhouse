using System;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Easing.Interfaces;

namespace Birdhouse.Tools.Easing
{
    public static class EasingExtensions
    {
        public static IEase InverseX(this IEase ease)
        {
            var result = new Ease(Apply);
            return result;

            float Apply(float progress)
            {
                var value = ease.Evaluate(1 - progress);
                return value;
            }
        }

        public static IEase InverseY(this IEase ease)
        {
            var result = new Ease(Apply);
            return result;
            
            float Apply(float progress)
            {
                var value = 1 - ease.Evaluate(progress);
                return value;
            }
        }

        public static IEase Increase(this IEase ease, float value)
        {
            var result = ease.Modify(value, EasingHelper.Operations.Increase);
            return result;
        }

        public static IEase Decrease(this IEase ease, float value)
        {
            var result = ease.Modify(value, EasingHelper.Operations.Decrease);
            return result;
        }

        public static IEase Multiple(this IEase ease, float value)
        {
            var result = ease.Modify(value, EasingHelper.Operations.Multiple);
            return result;
        }

        public static IEase Divide(this IEase ease, float value)
        { 
            var result = ease.Modify(value, EasingHelper.Operations.Divide);
            return result;
        }

        public static IEase Modulus(this IEase ease, float value)
        {
            var result = ease.Modify(value, EasingHelper.Operations.Modulus);
            return result;
        }

        public static IEase Power(this IEase ease, float value)
        {
            var result = ease.Modify(value, EasingHelper.Operations.Power);
            return result;
        }

        public static IEase Average(this IEase ease, float value)
        {
            var result = ease.Modify(value, EasingHelper.Operations.Average);
            return result;
        }
        
        public static IEase Increase(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Increase);
            return result;
        }

        public static IEase Decrease(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Decrease);
            return result;
        }

        public static IEase Multiple(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Multiple);
            return result;
        }

        public static IEase Divide(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Divide);
            return result;
        }

        public static IEase Modulus(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Modulus);
            return result;
        }

        public static IEase Power(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Power);
            return result;
        }

        public static IEase Average(this IEase ease, IEase other)
        {
            var result = ease.Modify(other.Evaluate, EasingHelper.Operations.Average);
            return result;
        }
        
        public static IEase Modify(this IEase ease, Func<float> func, Func<float, float, float> operation)
        {
            var result = ease.Modify(_ => func.Invoke(), operation);
            return result;
        }

        public static IEase Modify(this IEase ease, float value, Func<float, float, float> operation)
        {
            var result = ease.Modify(_ => value, operation);
            return result;
        }

        public static IEase Modify(this IEase ease, Func<float, float> func, Func<float, float, float> operation)
        {
            var result = new Ease(Combine);
            return result;
            
            float Combine(float value)
            {
                var oldValue = ease.Evaluate(value);
                var newValue = func.Invoke(value);

                var combinedValue = operation.Invoke(oldValue, newValue);
                return combinedValue;
            }
        }
    }
}

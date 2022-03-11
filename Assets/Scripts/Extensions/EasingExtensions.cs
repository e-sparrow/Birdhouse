using System;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Tools.Easing;
using ESparrow.Utils.Tools.Easing.Interfaces;

namespace ESparrow.Utils.Extensions
{
    public static class EasingExtensions
    {
        public static IEase InverseX(this IEase ease)
        {
            var temp = (Func<float, float>) ease.Evaluate;
            return new Ease(Apply);

            float Apply(float progress)
            {
                return temp.Invoke(1 - progress);
            }
        }

        public static IEase InverseY(this IEase ease)
        {
            var temp = (Func<float, float>) ease.Evaluate;
            return new Ease(Apply);

            float Apply(float progress)
            {
                return 1 - temp.Invoke(progress);
            }
        }

        public static IEase Increase(this IEase ease, float value)
        {
            return ease.Modify(value, EasingHelper.Operations.Increase);
        }

        public static IEase Decrease(this IEase ease, float value)
        {
            return ease.Modify(value, EasingHelper.Operations.Decrease);
        }

        public static IEase Multiple(this IEase ease, float value)
        {
            return ease.Modify(value, EasingHelper.Operations.Multiple);
        }

        public static IEase Divide(this IEase ease, float value)
        { 
            return ease.Modify(value, EasingHelper.Operations.Divide);
        }

        public static IEase Modulus(this IEase ease, float value)
        {
            return ease.Modify(value, EasingHelper.Operations.Modulus);
        }

        public static IEase Power(this IEase ease, float value)
        {
            return ease.Modify(value, EasingHelper.Operations.Power);
        }

        public static IEase Average(this IEase ease, float value)
        {
            return ease.Modify(value, EasingHelper.Operations.Average);
        }
        
        public static IEase Increase(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Increase);
        }

        public static IEase Decrease(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Decrease);
        }

        public static IEase Multiple(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Multiple);
        }

        public static IEase Divide(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Divide);
        }

        public static IEase Modulus(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Modulus);
        }

        public static IEase Power(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Power);
        }

        public static IEase Average(this IEase ease, IEase other)
        {
            return ease.Modify(other.Evaluate, EasingHelper.Operations.Average);
        }

        public static IEase Modify(this IEase ease, Func<float, float> func, Func<float, float, float> operation)
        {
            var temp = (Func<float, float>) ease.Evaluate;
            return new Ease(Combine);
            
            float Combine(float value)
            {
                var oldValue = temp.Invoke(value);
                var newValue = func.Invoke(value);

                var combinedValue = operation.Invoke(oldValue, newValue);
                return combinedValue;
            }
        }
        
        public static IEase Modify(this IEase ease, Func<float> func, Func<float, float, float> operation)
        {
            return ease.Modify(_ => func.Invoke(), operation);
        }

        public static IEase Modify(this IEase ease, float value, Func<float, float, float> operation)
        {
            return ease.Modify(_ => value, operation);
        }
    }
}

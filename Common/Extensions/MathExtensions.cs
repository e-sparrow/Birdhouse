using System;
using Birdhouse.Common.Helpers;
using UnityEngine;

namespace Birdhouse.Common.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Power self value in specified value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="power">Power value</param>
        /// <returns>Self in specified power</returns>
        public static double Power(this double self, double power)
        {
            var result = Math.Pow(self, power);
            return result;
        }

        /// <summary>
        /// Square of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Self value in square power</returns>
        public static double Square(this double self)
        {
            var result = self.Power(2);
            return result;
        }

        /// <summary>
        /// Specified root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="root">Root value</param>
        /// <returns>Self value in specified root</returns>
        public static double Root(this double self, double root)
        {
            var result = self.Power(1f / root);
            return result;
        }

        /// <summary>
        /// Returns square root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Square root of self value</returns>
        public static double Sqrt(this double self)
        {
            var result = Math.Sqrt(self);
            return result;
        }

        /// <summary>
        /// Power self value in specified value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="power">Power value</param>
        /// <returns>Self in specified power</returns>
        public static float Power(this float self, float power)
        {
            var result = Mathf.Pow(self, power);
            return result;
        }

        /// <summary>
        /// Square of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Self value in square power</returns>
        public static float Square(this float self)
        {
            var result = self.Power(2);
            return result;
        }

        /// <summary>
        /// Specified root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="root">Root value</param>
        /// <returns>Self value in specified root</returns>
        public static double Root(this float self, float root)
        {
            var result = self.Power(1f / root);
            return result;
        }

        /// <summary>
        /// Returns square root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Square root of self value</returns>

        public static float Sqrt(this float self)
        {
            var result = Mathf.Sqrt(self);
            return result;
        }
        
        /// <summary>
        /// Rounds value with specified step.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="step">Step</param>
        /// <returns>Rounded value</returns>
        public static int RoundWithStep(this int self, int step)
        {
            var result = self / step * step;
            return result;
        }

        /// <summary>
        /// Rounds value with specified step.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="step">Step</param>
        /// <returns>Rounded value</returns>
        public static double RoundWithStep(this double self, double step)
        {
            var result = (int) (self / step) * step;
            return result;
        }

        /// <summary>
        /// Rounds value with specified step.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="step">Step</param>
        /// <returns>Rounded value</returns>
        public static float RoundWithStep(this float self, float step)
        {
            var result = (int) (self / step) * step;
            return result;
        }

        /// <summary>
        /// Loops value by specified min and max;
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns>Return looped value</returns>
        public static float LoopBetween(this float self, float min, float max)
        {
            var delta = max - min;

            self %= delta;
            self += min;

            if (self < 0)
            {
                self += max;
            }

            return self;
        }

        /// <summary>
        /// Loops value by specified min and max;
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns>Return looped value</returns>
        public static int LoopBetween(this int self, int min, int max)
        {
            var delta = max - min;

            self %= delta;
            self += min;

            if (self < 0)
            {
                self += max;
            }

            return self;
        }
    }
}

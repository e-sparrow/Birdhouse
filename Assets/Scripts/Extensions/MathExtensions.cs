using System;
using UnityEngine;

namespace ESparrow.Utils.Extensions
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
            return Math.Pow(self, power);
        }

        /// <summary>
        /// Square of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Self value in square power</returns>
        public static double Square(this double self)
        {
            return self.Power(2);
        }

        /// <summary>
        /// Specified root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="root">Root value</param>
        /// <returns>Self value in specified root</returns>
        public static double Root(this double self, double root)
        {
            return self.Power(1f / root);
        }

        /// <summary>
        /// Returns square root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Square root of self value</returns>
        public static double Sqrt(this double self)
        {
            return Math.Sqrt(self);
        }

        /// <summary>
        /// Power self value in specified value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="power">Power value</param>
        /// <returns>Self in specified power</returns>
        public static float Power(this float self, float power)
        {
            return Mathf.Pow(self, power);
        }

        /// <summary>
        /// Square of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Self value in square power</returns>
        public static float Square(this float self)
        {
            return self.Power(2);
        }

        /// <summary>
        /// Specified root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="root">Root value</param>
        /// <returns>Self value in specified root</returns>
        public static double Root(this float self, float root)
        {
            return self.Power(1f / root);
        }

        /// <summary>
        /// Returns square root of self value.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <returns>Square root of self value</returns>

        public static float Sqrt(this float self)
        {
            return Mathf.Sqrt(self);
        }
        
        /// <summary>
        /// Rounds value with specified step.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="step">Step</param>
        /// <returns>Rounded value</returns>
        public static int RoundWithStep(this int self, int step)
        {
            return self / step * step;
        }

        /// <summary>
        /// Rounds value with specified step.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="step">Step</param>
        /// <returns>Rounded value</returns>
        public static double RoundWithStep(this double self, double step)
        {
            return (int) (self / step) * step;
        }

        /// <summary>
        /// Rounds value with specified step.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="step">Step</param>
        /// <returns>Rounded value</returns>
        public static float RoundWithStep(this float self, float step)
        {
            return (int) (self / step) * step;
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
            float delta = max - min;

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
            int delta = max - min;

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

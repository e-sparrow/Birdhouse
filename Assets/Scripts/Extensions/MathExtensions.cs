using System;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class MathExtensions
    {
        public static double Power(this double self, double power)
        {
            return Math.Pow(self, power);
        }

        public static double Square(this double self)
        {
            return self.Power(2);
        }

        public static double Root(this double self, double root)
        {
            return self.Power(1f / root);
        }

        public static double Sqrt(this double self)
        {
            return Math.Sqrt(self);
        }

        public static float Power(this float self, float power)
        {
            return Mathf.Pow(self, power);
        }

        public static float Square(this float self)
        {
            return self.Power(2);
        }

        public static float Sqrt(this float self)
        {
            return Mathf.Sqrt(self);
        }

        public static int RoundWithStep(this int self, int step)
        {
            return self / step * step;
        }

        public static double RoundWithStep(this double self, double step)
        {
            return (int) (self / step) * step;
        }

        public static float RoundWithStep(this float self, float step)
        {
            return (int) (self / step) * step;
        }

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

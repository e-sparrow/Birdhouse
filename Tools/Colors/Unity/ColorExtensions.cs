using System;
using UnityEngine;

namespace Birdhouse.Tools.Colors.Unity
{
    public static class ColorExtensions
    {
        public static HSV ToHSV(this Color self)
        {
            float delta, min;
            float h = 0, s, v;

            min = Math.Min(Math.Min(self.r, self.g), self.b);
            v = Math.Max(Math.Max(self.r, self.g), self.b);
            
            delta = v - min;

            if (v == 0f)
            {
                s = 0f;
            }
            else
            {
                s = delta / v;
            }

            if (s == 0f)
            {
                h = 0f;
            }
            else
            {
                if (Math.Abs(self.r - v) <= float.Epsilon)
                {
                    h = (self.g - self.b) / delta;
                }
                else if (Math.Abs(self.g - v) <= float.Epsilon)
                {
                    h = 2f + (self.b - self.r) / delta;
                }
                else if (Math.Abs(self.b - v) <= float.Epsilon)
                {
                    h = 4f + (self.r - self.g) / delta;
                }

                h *= 60f;

                if (h < 0f)
                {
                    h += 360f;
                }
            }

            return new HSV(h, s, v / 255f);
        }

        public static Color ToRGB(this HSV self)
        {
            throw new NotImplementedException();
        }
    }
}
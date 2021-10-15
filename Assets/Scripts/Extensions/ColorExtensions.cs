using System;
using System.Globalization;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a color to string in hexadecimal. 
        /// </summary>
        /// <param name="color">Color to convert</param>
        /// <returns>Hexadecimal code of a color</returns>
        public static string ToHexadecimal(this Color color)
        {
            var code = "#";
            
            code += ToInt(color.r).ToString("X2");
            code += ToInt(color.g).ToString("X2");
            code += ToInt(color.b).ToString("X2");
            code += ToInt(color.a).ToString("X2");

            return code;

            static int ToInt(float from)
            {
                return (int) (from * 255);
            }
        }

        /// <summary>
        /// Converts hexadecimal code to string.
        /// </summary>
        /// <param name="hex">Hexadecimal code of color</param>
        /// <returns>Color from hexadecimal code</returns>
        /// <exception cref="Exception">Wrong code length</exception>
        public static Color FromHexadecimal(this string hex)
        {
            hex = hex.TrimStart('#');

            if (hex.Length == 6)
            {
                return GetColor();
            }
            else if (hex.Length == 8)
            {
                var alpha = Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
                return GetColor().SetAlpha(alpha);
            }
            else
            {
                throw new Exception("Hexadecimal code assuming length equals 6 or 8");
            }

            Color GetColor()
            {
                var red = Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                var green = Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
                var blue = Parse(hex.Substring(4, 2), NumberStyles.HexNumber);

                return new Color(red, green, blue);
            }

            float Parse(string text, NumberStyles styles)
            {
                return int.Parse(text, styles) / 255f;
            }
        }

        /// <summary>
        /// Modifies a color's alpha.
        /// </summary>
        /// <param name="color">Color to change alpha</param>
        /// <param name="alpha">Necessary alpha value from 0 to 1</param>
        /// <returns>Color with modified alpha channel value</returns>
        public static Color SetAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}

using System;
using System.Globalization;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Представляет цвет в виде шестнадцатиричного кода (например, #FFFFFFFF)
        /// </summary>
        public static string ToHexadecimal(this Color color)
        {
            string code = "#";
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
        /// Возвращает тот же цвет с указанным в аргументе значением прозрачности.
        /// </summary>
        public static Color SetAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}

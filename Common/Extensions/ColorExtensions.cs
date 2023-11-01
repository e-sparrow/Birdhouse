using System;
using Birdhouse.Common.Reflection.Conversions.Interfaces;
using Birdhouse.Common.Reflection.Conversions.Routine;
using UnityEngine;

namespace Birdhouse.Common.Extensions
{
    public static class ColorExtensions
    {
        private static readonly IReversibleSpecificTypedConversion<Color, string> Conversion 
            = new ReversibleColorToStringConversion();

        /// <summary>
        /// Converts a color to string in hexadecimal. 
        /// </summary>
        /// <param name="color">Color to convert</param>
        /// <returns>Hexadecimal code of a color</returns>
        public static string ToHexadecimal(this Color color)
        {
            var result = Conversion.Convert(color);
            return result;
        }

        /// <summary>
        /// Converts hexadecimal code to string.
        /// </summary>
        /// <param name="hex">Hexadecimal code of color</param>
        /// <returns>Color from hexadecimal code</returns>
        /// <exception cref="Exception">Wrong code length</exception>
        public static Color FromHexadecimal(this string hex)
        {
            var result = Conversion.Convert(hex);
            return result;
        }

        /// <summary>
        /// Modifies a color's alpha.
        /// </summary>
        /// <param name="color">Color to change alpha</param>
        /// <param name="alpha">Necessary alpha value from 0 to 1</param>
        /// <returns>Color with modified alpha channel value</returns>
        public static Color SetAlpha(this Color color, float alpha)
        {
            var result = new Color(color.r, color.g, color.b, alpha);
            return result;
        }
    }
}

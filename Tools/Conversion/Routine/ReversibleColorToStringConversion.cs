using System;
using System.Globalization;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Tools.Conversion.Routine
{
    public class ReversibleColorToStringConversion : ReversibleSpecificTypedConversionBase<Color, string>
    {
        public override string Convert(Color value)
        {
            var code = "#";
            
            code += ToInt(value.r).ToString("X2");
            code += ToInt(value.g).ToString("X2");
            code += ToInt(value.b).ToString("X2");
            code += ToInt(value.a).ToString("X2");

            return code;

            static int ToInt(float from)
            {
                var result = (int) (from * 255);
                return result;
            }
        }

        public override Color Convert(string value)
        {
            value = value.TrimStart('#');

            switch (value.Length)
            {
                case 6:
                    return GetColor();
                case 8:
                    var alpha = Parse(value.Substring(6, 2), NumberStyles.HexNumber);
                    return GetColor().SetAlpha(alpha);
            }

            throw new ArgumentException("Hexadecimal code assuming length equals 6 or 8");

            Color GetColor()
            {
                var red = Parse(value.Substring(0, 2), NumberStyles.HexNumber);
                var green = Parse(value.Substring(2, 2), NumberStyles.HexNumber);
                var blue = Parse(value.Substring(4, 2), NumberStyles.HexNumber);

                var result = new Color(red, green, blue);
                return result;
            }

            float Parse(string text, NumberStyles styles)
            {
                var result = int.Parse(text, styles) / 255f;
                return result;
            }
        }
    }
}

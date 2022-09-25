using System;
using System.Globalization;
using Birdhouse.Common.Extensions;
using UnityEngine;

namespace Birdhouse.Tools.Conversion.Specific
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
                return (int) (from * 255);
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

            throw new Exception("Hexadecimal code assuming length equals 6 or 8");

            Color GetColor()
            {
                var red = Parse(value.Substring(0, 2), NumberStyles.HexNumber);
                var green = Parse(value.Substring(2, 2), NumberStyles.HexNumber);
                var blue = Parse(value.Substring(4, 2), NumberStyles.HexNumber);

                return new Color(red, green, blue);
            }

            float Parse(string text, NumberStyles styles)
            {
                return int.Parse(text, styles) / 255f;
            }
        }
    }
}

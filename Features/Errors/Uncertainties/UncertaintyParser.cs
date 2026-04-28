using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Birdhouse.Features.Errors
{
    public static class UncertaintyParser
    {
        private static readonly NumberFormatInfo NumberFormat = CultureInfo.InvariantCulture.NumberFormat;
        
        public static bool TryParseInt(string input, out int origin, out int negativeError, out int positiveError, out bool isNegativePercent, out bool isPositivePercent)
        {
            origin = 0;
            negativeError = 0;
            positiveError = 0;
            isNegativePercent = false;
            isPositivePercent = false;
    
            if (TryParse(input, out var fOrigin, out var fNegativeError, out var fPositiveError, out isNegativePercent, out isPositivePercent))
            {
                origin = Mathf.RoundToInt(fOrigin);
                negativeError = Mathf.RoundToInt(fNegativeError);
                positiveError = Mathf.RoundToInt(fPositiveError);
                return true;
            }
    
            return false;
        }
        
        public static bool TryParse(string input, out float origin, out float negativeError, out float positiveError, out bool isNegativePercent, out bool isPositivePercent)
        {
            origin = 0;
            negativeError = 0;
            positiveError = 0;
            isNegativePercent = false;
            isPositivePercent = false;

            input = input.Replace("+-", "±");
            input = input.Replace(" ", "");
            input = input.Replace(",", ".");

            var cleaned = Regex.Replace(input, @"[^0-9\+\-\/%\.±]", "");

            // Асимметричная
            var plusIndex = cleaned.IndexOf('+');
            var slashIndex = cleaned.IndexOf('/');

            if (plusIndex != -1 && slashIndex != -1)
            {
                var originString = cleaned.Substring(0, plusIndex);
                if (!float.TryParse(originString, NumberStyles.Float, NumberFormat, out origin)) return false;

                var positiveString = cleaned.Substring(plusIndex + 1, slashIndex - plusIndex - 1);
                if (!TryParseError(positiveString, out positiveError, out isPositivePercent)) return false;

                var negativeStart = slashIndex + 1;
                var negativeString = cleaned.Substring(negativeStart).TrimStart('-');
                if (!TryParseError(negativeString, out negativeError, out isNegativePercent)) return false;

                return true;
            }

            // Симметричная
            var plusMinusIndex = cleaned.IndexOf('±');
            if (plusMinusIndex != -1)
            {
                var originString = cleaned.Substring(0, plusMinusIndex);
                if (!float.TryParse(originString, NumberStyles.Float, NumberFormat, out origin)) return false;

                var errorString = cleaned.Substring(plusMinusIndex + 1);
                if (!TryParseError(errorString, out var error, out var isPercent)) return false;

                negativeError = error;
                positiveError = error;
                isNegativePercent = isPercent;
                isPositivePercent = isPercent;
                return true;
            }

            // Без ошибки
            return float.TryParse(cleaned, NumberStyles.Float, NumberFormat, out origin);
        }

        public static bool TryParse(string input, ErrorProviderSettings settings, out IUncertainty<float> uncertainty)
        {
            uncertainty = null;
            
            var result = TryParse(input, out var origin, out var negativeError, out var positiveError, out var isNegativePercent, out var isPositivePercent);
            if (result) uncertainty = new FloatUncertainty(ErrorProviderFactory.Create(settings), origin, negativeError, positiveError, isNegativePercent, isPositivePercent);
            return result;
        }

        private static bool TryParseError(string errorString, out float value, out bool isPercent)
        {
            value = 0;
            isPercent = false;

            isPercent = errorString.EndsWith("%");
            if (isPercent) errorString = errorString.TrimEnd('%');

            return float.TryParse(errorString, NumberStyles.Float, NumberFormat, out value);
        }
    }
}
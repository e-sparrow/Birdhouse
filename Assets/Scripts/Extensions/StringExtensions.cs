using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class StringExtension
    {
        public static string GetPart(this string text, float percent)
        {
            int count = (int) (text.Length * percent);
            return text.Substring(0, count);
        }

        public static string Colored(this string text, Color color)
        {
            return $"<color={color.ToHexadecimal()}>{text}</color>";
        }

        public static string Bold(this string text)
        {
            return $"<b>{text}</b>";
        }
    }
}
    
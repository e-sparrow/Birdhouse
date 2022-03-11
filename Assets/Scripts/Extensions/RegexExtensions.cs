using System;
using System.Text.RegularExpressions;

namespace ESparrow.Utils.Extensions
{
    public static class RegexExtensions
    {
        public static Regex CreateRegex(this string pattern, RegexOptions options = default, TimeSpan matchTimeout = default)
        {
            return new Regex(pattern, options, matchTimeout);
        }
    }
}
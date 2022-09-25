﻿using System;
using System.Text.RegularExpressions;

namespace Birdhouse.Common.Helpers
{
    public static class RegexHelper
    {
        private const string MultipleSpacesRegexPattern = "\\s+";

        public static Regex CreateMultipleSpacesRegex(RegexOptions options = default, TimeSpan matchTimeout = default)
        {
            var regex = new Regex(MultipleSpacesRegexPattern, options, matchTimeout);
            return regex;
        }
    }
}
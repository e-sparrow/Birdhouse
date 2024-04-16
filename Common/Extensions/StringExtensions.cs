using System;
using System.Collections.Generic;
using Birdhouse.Common.Constants;
using Birdhouse.Common.Helpers;
using UnityEngine;

namespace Birdhouse.Common.Extensions
{
    public static class StringExtension
    {
        public static IEnumerator<string> SplitCamelCase(this string self)
        {
            var isInvalid = string.IsNullOrEmpty(self);
            if (isInvalid)
            {
                throw new ArgumentException($"Can't split null or empty string!");
            }
            
            var currentWord = string.Empty;

            var previousCharacter = self[0];
            for (var i = 1; i < self.Length; i++)
            {
                var currentCharacter = self[i];
                
                var nextWord = char.IsLower(previousCharacter) && char.IsUpper(currentCharacter);
                if (nextWord)
                {
                    yield return currentWord;
                    currentWord = string.Empty;
                }

                currentWord += currentCharacter;
            }
        }
        
        /// <summary>
        /// Gets a part of string by specified share
        /// </summary>
        /// <param name="text">String to divide into parts</param>
        /// <param name="share">Specified share of string</param>
        /// <returns>Part of string</returns>
        public static string GetPart(this string text, float share)
        {
            int count = (int) (text.Length * share);
            return text.Substring(0, count);
        }

        /// <summary>
        /// Sets the color to string.
        /// </summary>
        /// <param name="text">Text to paint</param>
        /// <param name="color">Text color</param>
        /// <returns>Colored string</returns>
        public static string WithColor(this string text, Color color)
        {
            return $"<color={color.ToHexadecimal()}>{text}</color>";
        }

        /// <summary>
        /// Makes the string bold.
        /// </summary>
        /// <param name="text">Text to make bold</param>
        /// <returns>Bold string</returns>
        public static string Bold(this string text)
        {
            return $"<b>{text}</b>";
        }

        /// <summary>
        /// Resizes the string.
        /// </summary>
        /// <param name="text">String to resize</param>
        /// <param name="size">Target size</param>
        /// <returns>Resized string</returns>
        public static string Sized(this string text, int size)
        {
            return $"<size={size}>{text}</size>";
        }

        /// <summary>
        /// Cleanses string from multiple spaces ("  ", f.e.)
        /// </summary>
        /// <param name="self">Dirty string</param>
        /// <returns>Clean string</returns>
        public static string ClearMultipleSpaces(this string self)
        {
            var regex = RegexHelper.CreateMultipleSpacesRegex();
            
            var clearString = regex.Replace(self, StringConstants.Space);
            return clearString;
        }
    }
}
    
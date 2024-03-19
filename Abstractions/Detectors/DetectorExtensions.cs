using System;
using System.Text.RegularExpressions;
using Birdhouse.Abstractions.Detectors.Interfaces;

namespace Birdhouse.Abstractions.Detectors
{
    public static class DetectorExtensions
    {
        public static IDisposable RegisterBanRegex(this IDetector<string> self, string pattern)
        {
            var result = self.RegisterBanRule(value => Regex.IsMatch(value, pattern));
            return result;
        }
        
        public static IDisposable RegisterBanRegex(this IDetector<string> self, Regex regex)
        {
            var result = self.RegisterBanRule(value => regex.IsMatch(value));
            return result;
        }
        public static IDisposable RegisterExceptionRegex(this IDetector<string> self, string pattern)
        {
            var result = self.RegisterExceptionRule(value => Regex.IsMatch(value, pattern));
            return result;
        }
        
        public static IDisposable RegisterExceptionRegex(this IDetector<string> self, Regex regex)
        {
            var result = self.RegisterExceptionRule(value => regex.IsMatch(value));
            return result;
        }
    }
}
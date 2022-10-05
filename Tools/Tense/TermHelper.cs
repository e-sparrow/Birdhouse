using System;
using Birdhouse.Tools.Tense.Expiration;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Tense
{
    public static class TermHelper
    {
        public static ITermInfo CreateTermInfo()
        {
            var result = new TermInfo();
            return result;
        }

        public static ITermInfo CreateTermInfo(TimeSpan lifetime)
        {
            var expiration = GetExpirationTime();
                
            var result = new TermInfo(expiration);
            return result;

            DateTime GetExpirationTime()
            {
                var value = DateTime.Now.Add(lifetime);
                return value;
            }
        }
    }
}
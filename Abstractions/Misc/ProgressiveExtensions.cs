using System;
using Birdhouse.Abstractions.Misc.Interfaces;

namespace Birdhouse.Abstractions.Misc
{
    public static class ProgressiveExtensions
    {
        public static IProgressive AsProgressive(this Action<float> self, float initialValue = 0f)
        {
            var result = new Progressive(self, initialValue);
            return result;
        }
    }
}